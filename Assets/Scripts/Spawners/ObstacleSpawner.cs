using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject obstacle;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.gameManager.GetComponent<GameManager>();
        Instantiate(obstacle, transform.position, transform.rotation);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {

        yield return new WaitForSeconds(gm.spawnRate);
        Instantiate(obstacle, transform.position, transform.rotation);

        StopAllCoroutines();
        StartCoroutine(Timer());

    }

}