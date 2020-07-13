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

    public BeatmapLoader(string path) {
        pathToBeatmapFolder = path;
    }

    public void DebugExample()
    {
        Beatmap beatmap;

        beatmap = new Beatmap();
        beatmap.songLocation = "Intro_1_A1";
        beatmap.songName = "Tutorial_Level1";
        beatmap.start = 0f;
        beatmap.duration = 34.085f;
        beatmap.bpm = 120f;
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
        beatmap.duration = 32.54f;
        beatmap.bpm = 120f;
        beatmap.cues = new Cue[] {
            new Cue(14.7f, CueType.StartPosition, 4f, -11f),
            new Cue(14.83f, CueType.EndPosition, -1f, -6f),
            new Cue(31.1f, CueType.PlayerRepeat)
        };
        SaveData("tutorial1_fail", beatmap);

        beatmap.songLocation = "Intro_2_A1";
        beatmap.songName = "Tutorial_Level2";
        beatmap.start = 0f;
        beatmap.duration = 38.97f;
        beatmap.bpm = 120f;
        beatmap.cues = new Cue[] {
            new Cue(22.95f, CueType.StartPosition, -4f, -9f),
            new Cue(23.12f, CueType.EndPosition, -1f, -9f),
            new Cue(23.45f, CueType.EndPosition, -1f, -9f),
            new Cue(23.6f, CueType.EndPosition, -1f, -12f),
            new Cue(23.95f, CueType.EndPosition, -1f, -12f),
            new Cue(24.05f, CueType.EndPosition, -1f, -9f),
            new Cue(24.456f, CueType.EndPosition, -1f, -9f),
            new Cue(24.55f, CueType.EndPosition, 3f, -9f),
            new Cue(24.97f, CueType.EndPosition, 3f, -9f),
            new Cue(26.5f, CueType.EndPosition, -4f, -9f),
            new Cue(27.02f, CueType.EndPosition, -4f, -9f),
            new Cue(27.18f, CueType.EndPosition, -1f, -7f),
            new Cue(27.519f, CueType.EndPosition, -1f, -7f),
            new Cue(27.69f, CueType.EndPosition, 3f, -9f),
            new Cue(28.02f, CueType.EndPosition, 3f, -9f),
            new Cue(28.165f, CueType.EndPosition, -1f, -12f),
            new Cue(28.526f, CueType.EndPosition, -1f, -12f),
            new Cue(28.68f, CueType.EndPosition, -1f, -9f),
            new Cue(29.04f, CueType.EndPosition, -1f, -9f),
            new Cue(30.05f, CueType.Bell),
            new Cue(30.566f, CueType.EndPosition, -4f, -9f),
            new Cue(31.09f, CueType.PlayerRepeat)
        };
        SaveData("tutorial2", beatmap);

        beatmap.songLocation = "Intro_2_B1";
        beatmap.songName = "Tutorial_Level2_failed";
        beatmap.start = 0f;
        beatmap.duration = 32.37f;
        beatmap.bpm = 120f;
        beatmap.cues = new Cue[] {
            new Cue(16.32f, CueType.StartPosition, -4f, -9f),
            new Cue(16.49f, CueType.EndPosition, -1f, -9f),
            new Cue(16.82f, CueType.EndPosition, -1f, -9f),
            new Cue(16.97f, CueType.EndPosition, -1f, -12f),
            new Cue(17.32f, CueType.EndPosition, -1f, -12f),
            new Cue(17.42f, CueType.EndPosition, -1f, -9f),
            new Cue(17.826f, CueType.EndPosition, -1f, -9f),
            new Cue(17.92f, CueType.EndPosition, 3f, -9f),
            new Cue(18.34f, CueType.EndPosition, 3f, -9f),
            new Cue(19.87f, CueType.EndPosition, -4f, -9f),
            new Cue(20.39f, CueType.EndPosition, -4f, -9f),
            new Cue(20.55f, CueType.EndPosition, -1f, -7f),
            new Cue(20.889f, CueType.EndPosition, -1f, -7f),
            new Cue(21.06f, CueType.EndPosition, 3f, -9f),
            new Cue(21.39f, CueType.EndPosition, 3f, -9f),
            new Cue(21.535f, CueType.EndPosition, -1f, -12f),
            new Cue(21.869f, CueType.EndPosition, -1f, -12f),
            new Cue(22.05f, CueType.EndPosition, -1f, -9f),
            new Cue(22.41f, CueType.EndPosition, -1f, -9f),
            new Cue(23.42f, CueType.Bell),
            new Cue(23.936f, CueType.EndPosition, -4f, -9f),
            new Cue(24.46f, CueType.PlayerRepeat)
        };
        SaveData("tutorial2_fail", beatmap);

        beatmap.songLocation = "Intro_3_A1";
        beatmap.songName = "Tutorial_Level3";
        beatmap.start = 0f;
        beatmap.duration = 39.1f;
        beatmap.bpm = 120f;
        beatmap.cues = new Cue[] {
            new Cue(0f, CueType.StartPosition, 0f, -5f),
            new Cue(0f, CueType.EndPosition, 0f, -5f)
        };
        SaveData("tutorial3", beatmap);

        beatmap.songLocation = "Intro_3_B1";
        beatmap.songName = "Tutorial_Level3_failed";
        beatmap.start = 0f;
        beatmap.duration = 39.1f;
        beatmap.bpm = 120f;
        beatmap.cues = new Cue[] {
            new Cue(0f, CueType.StartPosition, 0f, -5f),
            new Cue(0f, CueType.EndPosition, 0f, -5f)
        };
        SaveData("tutorial3_fail", beatmap);

        beatmap.songLocation = "Intro_4_A1";
        beatmap.songName = "Tutorial_Level4";
        beatmap.start = 0f;
        beatmap.duration = 39.1f;
        beatmap.bpm = 120f;
        beatmap.cues = new Cue[] {
            new Cue(0f, CueType.StartPosition, 0f, -5f)
        };
        SaveData("tutorial3_fail", beatmap);
    }

    public void LoadFolder() {
        DirectoryInfo dir = new DirectoryInfo(pathToBeatmapFolder);
        DirectoryInfo[] info = dir.GetDirectories("*.*");
        numOfLevels = info.Length;
        beatmaps = new Beatmap[numOfLevels];
        for (int i = 0; i < numOfLevels; i++) {
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
