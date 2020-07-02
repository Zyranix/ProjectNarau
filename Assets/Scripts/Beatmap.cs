using System;

[Serializable]
public class Beatmap
{
    public string songLocation;
    public string songName;
    public float bpm;
    public float start;
    public float end;
    //public Vector[] difficulties;
    public Tuple<double, double, double>[] checkpoints; // timestamp, x-coord, y-coord

}
