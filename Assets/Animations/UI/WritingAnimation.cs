using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WritingAnimation : MonoBehaviour
{

    [Header("Texto to display")]
    public string msg;
    public float timeBetweenType = 0.1f;
    public bool repeat = false;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        msg = text.text;
        text.text = "";
        StartCoroutine(Timer());
    }

   IEnumerator Timer ()
    {
        text.text = "";

        for (int i = 0; i < msg.Length; i++)
        {

            text.text += msg[i];
            yield return new WaitForSeconds(timeBetweenType);

        }

        if (repeat)
        {
            yield return new WaitForSeconds(4);
            Repeating(); 
        }

    }

    void Repeating ()
    {
        StopAllCoroutines();
        StartCoroutine(Timer());

    }
}
