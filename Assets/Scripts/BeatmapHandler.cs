using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine;

public class BeatmapHandler : MonoBehaviour
{
    public PlayerLogic player;
    public Shower shower;
    public bool beatmapPlays { get; private set; }

    private AudioSource speaker;
    private AudioClip bell;
    private Beatmap map;
    private DateTime startTime;
    private float offset;

    private float? nextBellCueTime = null;

    private int nextCueId = 0;
    private Cue currentCue;
    private Cue nextCue;
    private bool handledCue = false;

    private bool playerRepeat = false;
    private List<float> proximityRatings;

    public async Task<bool> PlayBeatmap(Beatmap map)
    {
        this.map = map;
        InitializePlay();
        await Task.Delay((int)Math.Floor(this.map.duration * 1000));
        TerminatePlay();
        foreach (float rating in proximityRatings)
        {
            Debug.Log(rating);
        }
        Debug.Log(FinalRating());
        return FinalRating() > 0.6f;
    }

    public void Start()
    {
        bell = Resources.Load<AudioClip>("Sounds/Bell");
    }

    public void Update()
    {
        if (!beatmapPlays) return;

        if (NoFurtherCues())
        {
            if (!playerRepeat && BellCued() && (nextBellCueTime > ElapsedSeconds()))
            {
                RingBell();
            }
            else
            {
                return;
            }
        }

        if (!playerRepeat && !LastCue() && CueType.Bell == nextCue.Type)
        {
            if (BellCued()) return;
            nextBellCueTime = nextCue.Time;
            NextCue();
        }

        if (!playerRepeat && BellCued() && (nextBellCueTime <= ElapsedSeconds()))
        {
            RingBell();
        }

        if (!handledCue && !playerRepeat && CueType.StartPosition == currentCue.Type)
        {
            shower.JumpTo(currentCue.XPosition, currentCue.YPosition);
            handledCue = true;
        }

        if (!LastCue() && nextCue.Time <= ElapsedSeconds())
        {
            GoToNextCue();
            NextCue();
            handledCue = false;
        }

        if (!LastCue() && CueType.EndPosition == nextCue.Type)
        {
            if (CueType.StartPosition == currentCue.Type && currentCue.Time > ElapsedSeconds()) return;
            handleMovement();
        }

        if (CueType.PlayerRepeat == currentCue.Type)
        {
            if (playerRepeat)
            {
                playerRepeat = false;
                offset = 0f;
                GoToNextCue();
                NextCue();
            }
            else
            {
                playerRepeat = true;
                GoBackToSequenceStart();
            }
        }
    }

    private void InitializePlay()
    {
        if (map.cues.Length < 2) return;

        currentCue = map.cues[0];
        nextCueId = 1;
        nextCue = map.cues[nextCueId];
        nextBellCueTime = null;

        offset = 0f;

        proximityRatings = new List<float>();

        AudioClip clip = Resources.Load<AudioClip>(this.map.songLocation);
        if (speaker == null) speaker = gameObject.AddComponent<AudioSource>();
        handledCue = false;
        playerRepeat = false;
        beatmapPlays = true;
        startTime = DateTime.Now;
        speaker.PlayOneShot(clip);
    }

    private void TerminatePlay()
    {
        beatmapPlays = false;
    }

    private void RingBell()
    {
        speaker.PlayOneShot(bell);
        nextBellCueTime = null;
    }

    private void NextCue()
    {
        if (map.cues.Length - 1 <= nextCueId)
        {
            nextCue = null;
        }
        else
        {
            nextCue = map.cues[++nextCueId];
        }
    }

    private void GoToNextCue()
    {
        currentCue = nextCue;
    }

    private void GoBackToSequenceStart()
    {
        Cue playerRepeat = currentCue;
        while (nextCueId > 0 && (CueType.StartPosition != currentCue.Type))
        {
            currentCue = map.cues[--nextCueId];
        }
        nextCue = map.cues[++nextCueId];
        offset = playerRepeat.Time - currentCue.Time;
    }

    private bool NoFurtherCues()
    {
        return currentCue == null && nextCue == null;
    }

    private bool LastCue()
    {
        return nextCue == null;
    }

    private bool BellCued()
    {
        return nextBellCueTime != null;
    }

    private float ElapsedSeconds()
    {
        return (float)(DateTime.Now - startTime).TotalSeconds - offset;
    }

    private float CueProgress()
    {
        float cueTimeDelta = nextCue.Time - currentCue.Time;
        float runTimeDelta = ElapsedSeconds() - currentCue.Time;
        return runTimeDelta / cueTimeDelta;
    }

    private void handleMovement()
    {
        if (LastCue()) return;
        float deltaX = nextCue.XPosition - currentCue.XPosition;
        float deltaY = nextCue.YPosition - currentCue.YPosition;
        float interpolatedX = currentCue.XPosition + CueProgress() * deltaX;
        float interpolatedY = currentCue.YPosition + CueProgress() * deltaY;

        if (playerRepeat)
        {
            if (CueType.StartPosition != currentCue.Type)
                RateProximity(interpolatedX, interpolatedY);
        }
        else
        {
            shower.JumpTo(interpolatedX, interpolatedY);
        }
    }

    private void RateProximity(float targetX, float targetY)
    {
        float currentX = player.XPosition();
        float currentY = player.YPosition();
        float deltaX = targetX - currentX;
        float deltaY = targetY - currentY;
        float distance = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        float rating = 1f - 1f * distance * 0.2f;
        if (rating < 0) rating = 0;
        proximityRatings.Add(rating);
    }

    private float FinalRating()
    {
        if (proximityRatings.Count == 0) return 1;
        float sum = 0;
        foreach (float rating in proximityRatings)
        {
            sum += rating;
        }
        return sum / proximityRatings.Count;
    }

}
