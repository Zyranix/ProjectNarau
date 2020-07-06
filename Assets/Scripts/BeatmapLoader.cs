using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class BeatmapLoader : MonoBehaviour
{
    public Beatmap[] beatmaps;
    public string pathToBeatmapFolder;
    private Beatmap currentCopy;
    // currently const number, if we implement level editor, we need to have a look at that again!
    private int numOfLevels;
    // Start is called before the first frame update
    void Start()
    {



    }

    private void DebugExample()
    {
        beatmaps[0].songLocation = "tutorial1.mp3";
        beatmaps[0].songName = "Tutorialsong";
        beatmaps[0].start = 0f;
        beatmaps[0].end = 60f;
        beatmaps[0].bpm = 120f;
        beatmaps[0].checkpoints = new Tuple<double, double, double>[] { Tuple.Create(0.0, 10.0, 10.0), Tuple.Create(1.0, 20.0, 10.0) };
        SaveData("tutorial1", beatmaps[0]);
        currentCopy = LoadData("tutorial1");
        for (int i = 0; i < currentCopy.checkpoints.Length; i++)
            Debug.Log(currentCopy.checkpoints[i]);
    }
    // Update is called once per frame
    void Update()
    {

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
            Debug.Log(info[i].Name);
        }
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

        saveFile.Close();
        return loadedBeatmap;
    }
}
