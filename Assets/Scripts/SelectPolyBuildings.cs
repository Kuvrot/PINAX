using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPolyBuildings : MonoBehaviour
{

    public GameObject[] lowPolyBuildings;
    public GameObject[] highPolyBuildings;

    // Start is called before the first frame update
    void Start()
    {
     
        if (QualitySettings.GetQualityLevel() == 5)
        {
            foreach (var o in highPolyBuildings)
            {
                o.SetActive(true);
            }
        }
        else
        {
            foreach (var o in lowPolyBuildings)
            {
                o.SetActive(true);
            }
        }
    }
}
