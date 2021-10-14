using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float killHeight;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < killHeight)
        {
            Destroy(gameObject);
        }
    }
}
