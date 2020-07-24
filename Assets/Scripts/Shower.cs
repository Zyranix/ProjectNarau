using UnityEngine;
using UnityEngine.AI;

public class Shower : MonoBehaviour
{

    private PantoHandle lowerHandle;


    async void Start()
    {
        lowerHandle = GameObject.Find("Panto").GetComponent<LowerHandle>();
        await lowerHandle.SwitchTo(gameObject, 0.2f); // seems like this is max movement speed
    }
    
    void Update()
    {

    }

    public void JumpTo(float xPosition, float yPosition) {
        transform.position = new Vector3(xPosition, 0f, yPosition);
    }

}
