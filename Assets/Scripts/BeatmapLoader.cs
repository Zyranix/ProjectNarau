using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class BeatmapLoader
{
    public Beatmap[] beatmaps { get; private set; }
    public string pathToBeatmapFolder { get; private set; }
    // TODO: currently const number, if we implement level editor, we need to have a look at that again!
    public int numOfLevels { get; private set; }

    public BeatmapLoader(string path)
    {
        pathToBeatmapFolder = path;
    }

    public void DebugExample()
    {
        Beatmap beatmap;

        float beat;
        float dbar;
        float start;
        float repeat;
        beatmap = new Beatmap();
        beatmap.songLocation = "Intro_1_A1";
        beatmap.songName = "Tutorial_Level1";
        beatmap.start = 0f;
        beatmap.duration = 34.085f;
        beatmap.bpm = 117.5f;
        beatmap.cues = new Cue[] {
            new Cue(16.4f, CueType.StartPosition, 4f, -11f),
            new Cue(16.53f, CueType.EndPosition, -1f, -6f),
            new Cue(16.60f, CueType.EndPosition, -1f, -6f),
            new Cue(32.7f, CueType.PlayerRepeat)
        };
        SaveData("tutorial1", beatmap);

        beatmap.songLocation = "Intro_1_B1";
        beatmap.songName = "Tutorial_Level1_failed";
        beatmap.start = 0f;
        beatmap.duration = 24.420f;
        beatmap.bpm = 117.5f;
        beat = 60f / beatmap.bpm;
        start = 14.4f;
        repeat = start + beat * 16.9f;
        beatmap.cues = new Cue[] {
            new Cue(start + beat * 0.6f, CueType.StartPosition, 4f, -11f),
            new Cue(start + beat * 0.9f, CueType.EndPosition, -1f, -6f),
            new Cue(start + beat * 1.0f, CueType.EndPosition, -1f, -6f),
            new Cue(repeat, CueType.PlayerRepeat)
        };
        SaveData("tutorial1_fail", beatmap);

        beatmap.songLocation = "Intro_2_A1";
        beatmap.songName = "Tutorial_Level2";
        beatmap.start = 0f;
        beatmap.duration = 38.97f;
        beatmap.bpm = 117.5f;
        beat = 60f / beatmap.bpm;
        start = 22.80f; //beat 0 
        repeat = start + beat * 16f;
        beatmap.cues = new Cue[] {
            new Cue(start, CueType.StartPosition, -3f, -8f),
            new Cue(start + beat * 13.5f, CueType.Bell),
            new Cue(start + beat * 1.5f, CueType.EndPosition, 3f, -8f),
            new Cue(start + beat * 2.0f, CueType.EndPosition, 3f, -8f),
            new Cue(start + beat * 3.5f, CueType.EndPosition, 3f, -12f),
            new Cue(start + beat * 3.8f, CueType.EndPosition, 3f, -12f),
            new Cue(start + beat * 7.0f, CueType.EndPosition, -3f, -8f),
            new Cue(start + beat * 8.0f, CueType.EndPosition, -3f, -8f),

            new Cue(start + beat * 8.65f, CueType.EndPosition, -3f, -10f),
            new Cue(start + beat * 9.0f, CueType.EndPosition, -3f, -10f),
            new Cue(start + beat * 9.65f, CueType.EndPosition, -1f, -10f),
            new Cue(start + beat * 10.0f, CueType.EndPosition, -1f, -10f),
            new Cue(start + beat * 10.65f, CueType.EndPosition, -1f, -8f),
            new Cue(start + beat * 11.0f, CueType.EndPosition, -1f, -8f),
            new Cue(start + beat * 11.65f, CueType.EndPosition, -3f, -8f),
            new Cue(start + beat * 11.8f, CueType.EndPosition, -3f, -8f),
            new Cue(start + beat * 15.0f, CueType.EndPosition, 2f, -14f),
            new Cue(start + beat * 15.9f, CueType.EndPosition, 2f, -14f),
            new Cue(repeat, CueType.PlayerRepeat)
        };
        SaveData("tutorial2", beatmap);

        beatmap.songLocation = "Intro_2_B1";
        beatmap.songName = "Tutorial_Level2_failed";
        beatmap.start = 0f;
        beatmap.duration = 32.37f;
        beatmap.bpm = 117.5f;
        beat = 60f / beatmap.bpm;
        start = 16.30f; //beat 0
        repeat = start + beat * 16f;
        beatmap.cues = new Cue[] {
            new Cue(start, CueType.StartPosition, -3f, -8f),
            new Cue(start + beat * 13.5f, CueType.Bell),
            new Cue(start + beat * 1.5f, CueType.EndPosition, 3f, -8f),
            new Cue(start + beat * 2.0f, CueType.EndPosition, 3f, -8f),
            new Cue(start + beat * 3.5f, CueType.EndPosition, 3f, -12f),
            new Cue(start + beat * 3.8f, CueType.EndPosition, 3f, -12f),
            new Cue(start + beat * 7.0f, CueType.EndPosition, -3f, -8f),
            new Cue(start + beat * 8.0f, CueType.EndPosition, -3f, -8f),

            new Cue(start + beat * 8.65f, CueType.EndPosition, -3f, -10f),
            new Cue(start + beat * 9.0f, CueType.EndPosition, -3f, -10f),
            new Cue(start + beat * 9.65f, CueType.EndPosition, -1f, -10f),
            new Cue(start + beat * 10.0f, CueType.EndPosition, -1f, -10f),
            new Cue(start + beat * 10.65f, CueType.EndPosition, -1f, -8f),
            new Cue(start + beat * 11.0f, CueType.EndPosition, -1f, -8f),
            new Cue(start + beat * 11.65f, CueType.EndPosition, -3f, -8f),
            new Cue(start + beat * 11.8f, CueType.EndPosition, -3f, -8f),
            new Cue(start + beat * 15.0f, CueType.EndPosition, 2f, -14f),
            new Cue(start + beat * 15.9f, CueType.EndPosition, 2f, -14f),
            new Cue(repeat, CueType.PlayerRepeat)
        };
        SaveData("tutorial2_fail", beatmap);

        beatmap.songLocation = "Intro_3_A1";
        beatmap.songName = "Tutorial_Level3";
        beatmap.start = 0f;
        beatmap.duration = 49.293f;
        beatmap.bpm = 117.5f;
        beat = 60f / beatmap.bpm;
        start = 16.35f; //beat 0 | 16.35 beat 1
        dbar = beat * 8f;
        beatmap.cues = new Cue[] {
            new Cue(start + dbar * 0 + beat * 0.0f, CueType.StartPosition, 3f, -12f),
            new Cue(start + dbar * 0 + beat * 0.8f, CueType.EndPosition, 3f, -10f),
            new Cue(start + dbar * 0 + beat * 1.0f, CueType.EndPosition, 3f, -10f),
            new Cue(start + dbar * 0 + beat * 1.8f, CueType.EndPosition, 1f, -10f),
            new Cue(start + dbar * 0 + beat * 2.0f, CueType.EndPosition, 1f, -10f),
            new Cue(start + dbar * 0 + beat * 2.5f, CueType.EndPosition, 1f, -9f),
            new Cue(start + dbar * 0 + beat * 3.0f, CueType.EndPosition, 0f, -9f),
            new Cue(start + dbar * 0 + beat * 3.5f, CueType.EndPosition, 0f, -9f),
            new Cue(start + dbar * 0 + beat * 5.4f, CueType.Bell),
            new Cue(start + dbar * 0 + beat * 7.0f, CueType.EndPosition, 3f, -12f),
            new Cue(start + dbar * 0 + beat * 7.8f, CueType.EndPosition, 3f, -12f),
            new Cue(start + dbar * 0 + dbar, CueType.PlayerRepeat),
            new Cue(start + dbar * 2 + beat * 0.0f, CueType.StartPosition, 3f, -12f),
            new Cue(start + dbar * 2 + beat * 0.8f, CueType.EndPosition, 3f, -10f),
            new Cue(start + dbar * 2 + beat * 1.0f, CueType.EndPosition, 3f, -10f),
            new Cue(start + dbar * 2 + beat * 1.8f, CueType.EndPosition, 1f, -10f),
            new Cue(start + dbar * 2 + beat * 2.0f, CueType.EndPosition, 1f, -10f),
            new Cue(start + dbar * 2 + beat * 2.5f, CueType.EndPosition, 1f, -9f),
            new Cue(start + dbar * 2 + beat * 3.0f, CueType.EndPosition, 0f, -9f),
            new Cue(start + dbar * 2 + beat * 3.5f, CueType.EndPosition, 0f, -9f),
            new Cue(start + dbar * 2 + beat * 5.4f, CueType.Bell),
            new Cue(start + dbar * 2 + beat * 7.0f, CueType.EndPosition, 3f, -12f),
            new Cue(start + dbar * 2 + beat * 7.8f, CueType.EndPosition, 3f, -12f),
            new Cue(start + dbar * 2 + dbar, CueType.PlayerRepeat),
            new Cue(start + dbar * 4 + beat * 0.0f, CueType.StartPosition, 3f, -12f),
            new Cue(start + dbar * 4 + beat * 0.8f, CueType.EndPosition, 3f, -10f),
            new Cue(start + dbar * 4 + beat * 1.0f, CueType.EndPosition, 3f, -10f),
            new Cue(start + dbar * 4 + beat * 1.8f, CueType.EndPosition, 1f, -10f),
            new Cue(start + dbar * 4 + beat * 2.0f, CueType.EndPosition, 1f, -10f),
            new Cue(start + dbar * 4 + beat * 2.5f, CueType.EndPosition, 1f, -9f),
            new Cue(start + dbar * 4 + beat * 3.0f, CueType.EndPosition, 0f, -9f),
            new Cue(start + dbar * 4 + beat * 3.5f, CueType.EndPosition, 0f, -9f),
            new Cue(start + dbar * 4 + beat * 5.4f, CueType.Bell),
            new Cue(start + dbar * 4 + beat * 7.0f, CueType.EndPosition, 3f, -12f),
            new Cue(start + dbar * 4 + beat * 7.8f, CueType.EndPosition, 3f, -12f),
            new Cue(start + dbar * 4 + dbar, CueType.PlayerRepeat),
            new Cue(start + dbar * 6 + beat * 0.0f, CueType.StartPosition, 3f, -12f),
            new Cue(start + dbar * 6 + beat * 0.8f, CueType.EndPosition, 3f, -10f),
            new Cue(start + dbar * 6 + beat * 1.0f, CueType.EndPosition, 3f, -10f),
            new Cue(start + dbar * 6 + beat * 1.8f, CueType.EndPosition, 1f, -10f),
            new Cue(start + dbar * 6 + beat * 2.0f, CueType.EndPosition, 1f, -10f),
            new Cue(start + dbar * 6 + beat * 2.5f, CueType.EndPosition, 1f, -9f),
            new Cue(start + dbar * 6 + beat * 3.0f, CueType.EndPosition, 0f, -9f),
            new Cue(start + dbar * 6 + beat * 3.5f, CueType.EndPosition, 0f, -9f),
            new Cue(start + dbar * 6 + beat * 5.4f, CueType.Bell),
            new Cue(start + dbar * 6 + beat * 7.0f, CueType.EndPosition, 3f, -12f),
            new Cue(start + dbar * 6 + beat * 7.8f, CueType.EndPosition, 3f, -12f),
            new Cue(start + dbar * 6 + dbar, CueType.PlayerRepeat),
        };
        SaveData("tutorial3", beatmap);

        beatmap.songLocation = "Intro_3_B1";
        beatmap.songName = "Tutorial_Level3_failed";
        beatmap.start = 0f;
        beatmap.duration = 10f;
        beatmap.bpm = 117.5f;
        beatmap.cues = new Cue[] {
            new Cue(0f, CueType.StartPosition, 0f, -5f),
            new Cue(0f, CueType.EndPosition, 0f, -5f)
        };
        SaveData("tutorial3_fail", beatmap);

        beatmap.songLocation = "Intro_4_A1";
        beatmap.songName = "Tutorial_Level4";
        beatmap.start = 0f;
        beatmap.duration = 16.3f;
        beatmap.bpm = 117.5f;
        beatmap.cues = new Cue[] {
            new Cue(0f, CueType.StartPosition, 0f, -5f)
        };
        SaveData("tutorial4", beatmap);
    }

    public void LoadFolder()
    {
        DirectoryInfo dir = new DirectoryInfo(pathToBeatmapFolder);
        DirectoryInfo[] info = dir.GetDirectories("*.*");
        numOfLevels = info.Length;
        beatmaps = new Beatmap[numOfLevels];
        for (int i = 0; i < numOfLevels; i++)
        {
            beatmaps[i] = LoadData(info[i].Name);
        }
    }

    public void LoadFolder(string path)
    {
        pathToBeatmapFolder = path;
        LoadFolder();
    }

    public void SaveData(string location, Beatmap toSave)
    {
        // if (!Directory.Exists("Assets/Beatmaps"))
        //     Directory.CreateDirectory("Assets/Beatmaps");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create(pathToBeatmapFolder + location + "/" + location + ".dat");
        formatter.Serialize(saveFile, toSave);

        saveFile.Close();
    }

    public Beatmap LoadData(string location)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open(pathToBeatmapFolder + location + "/" + location + ".dat", FileMode.Open);

        Beatmap loadedBeatmap = (Beatmap)formatter.Deserialize(saveFile);
        loadedBeatmap.songLocation = "Tutorials/" + location + "/" + loadedBeatmap.songLocation;

        saveFile.Close();
        return loadedBeatmap;
    }
}
