using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [Header("Settings")]
    static public GameObject gameManager;
    public ShipController Player;

    [Header("Game stats")]
    public bool gameStarted = false;
    public float spawnRate = 10;
    public float obstacleSpeed = 50;
    public int score;
    public int HP = 3;
    public GameObject ObstacleSpawner;
    public GameObject startMessage;
    public GameObject statsUI;

    [Header("UI settings")]
    public Text UI_Score;
    public Text UI_HP;
    private bool UI_Initialized = false;

    //specific table
    public bool fixedTable = false; // This variable is used when the game uses an specific table, selected by the variable table, if it's false the game will just use and mix all the tables.
    public int table = 0;

    [Header("FX")]
    public ParticleSystem[] particles = new ParticleSystem[3]; //if correct effect 0, incorrect 1 and lost al HP 2

    //[HideInInspector]
    public float Clock = 0;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = this.gameObject;
        ObstacleSpawner.SetActive(false);
        statsUI.SetActive(false);
        startMessage.SetActive(true);
        score = 0;
        table = Table.table;
        fixedTable = Table.fixedTable;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                gameStarted = true;
                ObstacleSpawner.SetActive(true);
                statsUI.SetActive(true);
                Destroy(startMessage);
                UI_Setup();
                gameStarted = true; //start game
            }
        }
        else
        {
            if (Clock < 300)
            {
                Clock += 1 * Time.deltaTime;
                spawnRate = -0.0085f * Clock + 5;

            }else
            {
                spawnRate = 2.5f;
                Clock = 300;
            }

            if (UI_Initialized)
            {
                UI_Score.GetComponent<Text>().text = "score: " + score.ToString("F00");
                
                

                switch (HP)
                {
                    case 2: UI_HP.text = "HP: ##"; break;
                    case 1: UI_HP.text = "HP: #"; break;
                    case 0: UI_HP.text = "HP: "; StartCoroutine(DeathTimer()); break;
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        //Cheats
        if (Input.GetKeyDown(KeyCode.K))
        {
            Clock = 280;
            score = 43;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }




    }

    void UI_Setup()
    {
        UI_Score.GetComponent<WritingAnimation>().msg = "Score: " + score.ToString("F00");
        UI_HP.GetComponent<WritingAnimation>().msg = "HP: ###";
        StartCoroutine(Timer());
        
    }

    IEnumerator Timer ()
    {

        yield return new WaitForSeconds(2.5f);
        UI_Initialized = true;

    }

    public void CameraShake()
    {

        Player.GetComponent<Animator>().SetTrigger("shake");

    }

    IEnumerator DeathTimer() //wait a few seconds until the scene restarts after death
    {

        particles[1].Play();
        Player.GetComponent<ShipController>().ship.GetComponentInChildren<MeshRenderer>().enabled = false;   
        yield return new WaitForSeconds(5);
        
        if (!fixedTable)
        {
            PlayerPrefs.SetInt("Score", score);
        }

        SceneManager.LoadScene("MainMenu");
        StopAllCoroutines();


    }
}
