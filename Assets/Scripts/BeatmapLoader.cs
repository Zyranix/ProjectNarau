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
    private Beatmap currentCopy;
    // TODO: currently const number, if we implement level editor, we need to have a look at that again!
    public int numOfLevels { get; private set; }

    public BeatmapLoader(string path) {
        pathToBeatmapFolder = path;
    }

    public void DebugExample()
    {
        beatmaps = new Beatmap[1];
        beatmaps[0] = new Beatmap();
        beatmaps[0].songLocation = "Intro_1_A1";
        beatmaps[0].songName = "Tutorial_Level1";
        beatmaps[0].start = 0f;
        beatmaps[0].duration = 34.085f;
        beatmaps[0].bpm = 120f;
        beatmaps[0].cues = new Cue[] {
            new Cue(16.4f, CueType.StartPosition, 4f, -11f),
            new Cue(16.53f, CueType.EndPosition, -1f, -6f),
            new Cue(32.7f, CueType.PlayerRepeat)/*,
            new Cue(16.9f, CueType.EndPosition, -1f, -6f),
            new Cue(17.03f, CueType.EndPosition, -1f, -12f)*/
        };
        SaveData("tutorial1", beatmaps[0]);

        beatmaps[0] = new Beatmap();
        beatmaps[0].songLocation = "Intro_1_B1";
        beatmaps[0].songName = "Tutorial_Level1_failed";
        beatmaps[0].start = 0f;
        beatmaps[0].duration = 32.54f;
        beatmaps[0].bpm = 120f;
        beatmaps[0].cues = new Cue[] {
            new Cue(14.7f, CueType.StartPosition, 4f, -11f),
            new Cue(14.83f, CueType.EndPosition, -1f, -6f),
            new Cue(31.1f, CueType.PlayerRepeat)/*,
            new Cue(16.9f, CueType.EndPosition, -1f, -6f),
            new Cue(17.03f, CueType.EndPosition, -1f, -12f)*/
        };
        SaveData("tutorial1_fail", beatmaps[0]);
        currentCopy = LoadData("tutorial1_fail");
        for (int i = 0; i < currentCopy.cues.Length; i++)
            Debug.Log(currentCopy.cues[i]);
    }

    public void LoadFolder() {
        DirectoryInfo dir = new DirectoryInfo(pathToBeatmapFolder);
        DirectoryInfo[] info = dir.GetDirectories("*.*");
        numOfLevels = info.Length;
        beatmaps = new Beatmap[numOfLevels];
        for (int i = 0; i < 2; i++)
        {
            beatmaps[i] = LoadData(info[i].Name);
            Debug.Log(info[i].Name);
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
