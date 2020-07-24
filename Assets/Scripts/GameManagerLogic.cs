using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLogic : MonoBehaviour
{
    private TutorialManager tutorialManager;
    private CalibrationManager calibrationManager;
    // Start is called before the first frame update
    void Start() {
        Run();
    }

    async void Run() {
        calibrationManager = new CalibrationManager(gameObject.GetComponent<BeatmapHandler>().player,
            GameObject.Find("Panto").GetComponent<LowerHandle>());
        tutorialManager = new TutorialManager(gameObject.GetComponent<BeatmapHandler>());
        await calibrationManager.Execute();
        await tutorialManager.Execute();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
