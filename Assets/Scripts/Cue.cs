using System;

[Serializable]
public class Cue {
    public float Time;
    public CueType Type;
    public float XPosition;
    public float YPosition;

    public Cue(float time, CueType type, float xPosition = 0f, float yPosition = 0f) {
        Time = time;
        Type = type;
        XPosition = xPosition;
        YPosition = yPosition;
    }
}