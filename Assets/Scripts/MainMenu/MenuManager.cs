using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    static public int LanguageID = 0;
    static public bool languageChange = false;
    Button_Text[] Buttons;
    public Toggle fullScreen;
    public GameObject[] screens;

    public bool phoneMode = false;

    public int playerMoney = 1;
    public Text playerMoneyUI;

    // Start is called before the first frame update
    void Start()
    {
        Buttons = GameObject.FindObjectsOfType<Button_Text>();

        foreach (GameObject obj in screens)
        {
            obj.SetActive(false);
        }

        Cursor.visible = true;

        if (phoneMode)
        {
            Screen.SetResolution(915 , 412 , true);
        }

        if (PlayerPrefs.HasKey("Score"))
        {
            playerMoney = PlayerPrefs.GetInt("Score", playerMoney);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            LanguageChange(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            LanguageChange(1);
        }

        if (playerMoneyUI != null)
        {
            playerMoneyUI.text = "$" + playerMoney.ToString();
        }

    }

    public void LanguageChange (int id)
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

    public void Play(int n)
    {
        Table.fixedTable = true;
        Table.table = n;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    //Settings
    public void SetQuality(int n)
    {
        QualitySettings.SetQualityLevel(n);
    }

    public void Resolution (int n){

        switch (n)
        {
            case 0:
                Screen.SetResolution(1280 , 720, fullScreen.isOn); break;
            case 1:
                Screen.SetResolution(1920, 1080, fullScreen.isOn); break;
        }
    }
}
