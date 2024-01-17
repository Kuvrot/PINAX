using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{ 
    //Component
    Obstacle obstacle;

    // Start is called before the first frame update
    void Start()
    {
        obstacle = GetComponentInParent<Obstacle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            obstacle.playerAnswered = true;
        }
    }
}
