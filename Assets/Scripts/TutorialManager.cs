using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public BeatmapLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        loader.pathToBeatmapFolder = "Assets/Resources/Tutorials/"; //maybe have a look at resource loading
        loader.LoadFolder();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
