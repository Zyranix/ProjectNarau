using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using UnityEngine;

public class BeatmapHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource speaker;
    private float startTime;
    public PlayerLogic player;
    public Shower shower;
    public bool beatmapPlays { get; private set; }

    public void Start() {

    }

    public void Update() {
        if (!beatmapPlays) return;
        
    }

    public async Task<bool> PlayBeatmap(Beatmap tutorial)
    {
        AudioClip clip = Resources.Load<AudioClip>(tutorial.songLocation);
        speaker = gameObject.AddComponent<AudioSource>();
        speaker.PlayOneShot(clip);
        startTime = Time.time;
        await Task.Delay((int)Math.Floor(tutorial.duration * 1000));
        return false;
    }

}
