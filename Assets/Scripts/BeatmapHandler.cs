using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatmapHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource music;
    private float startTime;
    public PlayerLogic player;
    public Shower shower;
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool PlayBeatmap(ref Beatmap map)
    {
        AudioClip clip = Resources.Load<AudioClip>(map.songLocation);
        music.PlayOneShot(clip);
        startTime = Time.time;


        return true;

    }

}
