using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    //public GameObject player;
    public PlayerController playerScript;
    public float dmg;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to the Game Object in the Hierarchy / Scene
        //player = GameObject.Find("Player");
        //playerScript = player.GetComponent<PlayerController>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision happened");

        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.Damage(dmg);
            Debug.Log("Hazard hits player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
