using System;

[Serializable]
public class Beatmap
{
    public string songLocation; // without extension, starting from /Resources/
    public string songName;
    public float bpm;
    public float start; // might be not needed after all
    public float end;
    //public Vector[] difficulties;
    public Tuple<double, double, double>[] checkpoints; // timestamp, x-coord, y-coord

}
