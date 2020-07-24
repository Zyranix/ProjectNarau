using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private PantoHandle upperHandle;
    private float offsetX;
    private float offsetY;

    // AudioSource audioSource;
    // Health health;

    void Start()
    {
        upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        //await upperHandle.SwitchTo(gameObject, 0.5f); // seems like this is max movement speed
    }

    public void Calibrate(float actualX, float actualY) {
        offsetX = 0;
        offsetY = 0;

        offsetX = actualX - XPosition();
        offsetY = actualY - YPosition();
    }
    
    public float XPosition() {
        return (float)upperHandle.GetPosition().x + offsetX;
    }
    
    public float YPosition() {
        return (float)upperHandle.GetPosition().z + offsetY;        
    }
}
