using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private PantoHandle upperHandle;

    // AudioSource audioSource;
    // Health health;

    async void Start()
    {
        upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        //await upperHandle.SwitchTo(gameObject, 0.5f); // seems like this is max movement speed
    }
    
    public float XPosition() {
        return (float)upperHandle.GetPosition().x;
    }
    
    public float YPosition() {
        return (float)upperHandle.GetPosition().z;        
    }
}
