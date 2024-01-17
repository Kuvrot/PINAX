using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Text : MonoBehaviour
{

    public string[] text = new string[2];

    // Start is called before the first frame update
    void Start()
    {
        Translate();
    }

    public void Translate ()
    {

        GetComponentInChildren<Text>().text = text[MenuManager.LanguageID];

    }
}
