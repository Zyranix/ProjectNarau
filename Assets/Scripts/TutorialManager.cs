using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public struct NextBeatmap
{
    public NextBeatmap(int successMapId, int failureMapId)
    {
        SuccessMapId = successMapId;
        FailureMapId = failureMapId;
    }

    public int SuccessMapId;
    public int FailureMapId;
}

public class TutorialManager: BaseManager {
    private BeatmapLoader loader;
    private BeatmapHandler handler;
    private int currMapId = 2;
    private List<NextBeatmap> mapping;

    public TutorialManager(BeatmapHandler externalHandler)
    {
        handler = externalHandler;
    }

    private void Initialize()
    {
        loader = new BeatmapLoader("Assets/Resources/Tutorials/");

        loader.DebugExample();
        loader.LoadFolder(); //maybe have a look at resource loading

        mapping = new List<NextBeatmap>();

        mapping.Add(new NextBeatmap(2, 1));  // first tutorial
        mapping.Add(new NextBeatmap(2, 1));  // failing first tutorial
        mapping.Add(new NextBeatmap(4, 3));  // second tutorial
        mapping.Add(new NextBeatmap(4, 3));  // failing second tutorial
        mapping.Add(new NextBeatmap(6, 5));  // third tutorial
        mapping.Add(new NextBeatmap(6, 5));  // failing third tutorial
        mapping.Add(new NextBeatmap(7, 7));  // outro
    }
    public override async Task<bool> Execute() {
        Initialize();
        RunTutorial();
        return true;
    }

    private async void RunTutorial()
    {
        while (currMapId < loader.numOfLevels)
        {
            Debug.Log(currMapId);
            bool success = await handler.PlayBeatmap(loader.beatmaps[currMapId]);

            if (success)
            {
                Debug.Log("success");
                currMapId = mapping[currMapId].SuccessMapId;
            }
            else
            {
                Debug.Log("fail");
                currMapId = mapping[currMapId].FailureMapId;
            }
        }
    }
}
