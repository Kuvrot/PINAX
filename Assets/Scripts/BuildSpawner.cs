using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildSpawner : MonoBehaviour
{

    public float time;
    public static bool lowPoly = false;
    public GameObject building;

    public GameObject highPolybuildings;
    public GameObject lowPolyBuildings;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(building, transform.position, transform.rotation);
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !lowPoly)
        {
            lowPoly = true;
        }
        else if(Input.GetKeyDown(KeyCode.M) && lowPoly)
        {
            lowPoly = true;
        }

        building = QualitySettings.GetQualityLevel() == 5 ? highPolybuildings : lowPolyBuildings;
    }

    IEnumerator Timer ()
    {

        yield return new WaitForSeconds(time);
        Instantiate(building, transform.position, transform.rotation);
        StopAllCoroutines();
        StartCoroutine(Timer());
    }

}
