using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLogic : MonoBehaviour
{
    private TutorialManager tutorialManager;
    // Start is called before the first frame update
    void Start() {
        tutorialManager = new TutorialManager(gameObject.GetComponent<BeatmapHandler>());
        tutorialManager.Execute();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
