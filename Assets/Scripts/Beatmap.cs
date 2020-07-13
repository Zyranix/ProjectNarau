using System;

[Serializable]
public class Beatmap
{
    public string songLocation; // without extension, starting from /Resources/
    public string songName;
    public float bpm;
    public float start; // might be not needed after all
    public float duration;
    //public Vector[] difficulties;
    public Cue[] cues; // timestamp, checkpoint-type, x-coord, y-coord
}
