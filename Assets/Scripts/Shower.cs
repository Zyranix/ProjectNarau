using UnityEngine;
using UnityEngine.AI;

public class Shower : MonoBehaviour
{

    private PantoHandle lowerHandle;


    void Start()
    {
        lowerHandle = GameObject.Find("Panto").GetComponent<LowerHandle>();
    }

    void OnEnable()
    {
        //StartCoroutine(lowerHandle.SwitchTo(this, 0.5f)); // seems like this is max movement speed
    }



    void Update()
    {

    }






}
