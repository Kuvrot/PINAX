using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    static public short LanguageID = 0;
    static public bool languageChange = false;
    Button_Text[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
        Buttons = GameObject.FindObjectsOfType<Button_Text>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void LanguageChange (short id)
    {

        LanguageID = id;
        languageChange = true;

        for (int i = 0; i < Buttons.Length; i++)
        {

            Buttons[i].Translate();

        }

    }

    public void FreeMode()
    {

        Table.fixedTable = false;
        SceneManager.LoadScene(1);

    }

    public void Play (int n)
    {
        Table.fixedTable = true;
        Table.table = n;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    } 

}
