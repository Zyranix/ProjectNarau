using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    private PantoHandle upperHandle;

    // AudioSource audioSource;
    // Health health;

    void Start()
    {
        upperHandle = GameObject.Find("Panto").GetComponent<UpperHandle>();
        // health = GetComponent<Health>();
    }

    void Update()
    {
        transform.position = upperHandle.HandlePosition(transform.position);
    }
}
