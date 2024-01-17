using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpawner : MonoBehaviour
{

    public float time;
    public GameObject building;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(building, transform.position, transform.rotation);
        StartCoroutine(Timer());
    }
    IEnumerator Timer ()
    {

        yield return new WaitForSeconds(time);
        Instantiate(building, transform.position, transform.rotation);
        StopAllCoroutines();
        StartCoroutine(Timer());
    }

}
