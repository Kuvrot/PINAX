using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{

    public float movementSpeed = 50f;

    int firstValue, secondValue; //this are the values to use.

    public int[] options = { 0, 0, 0 };

    public Text[] values;

    public Text operation;

    public int correctAnswerID = 0;

    public bool playerAnswered; //this is true if the player gave an answer

    //Components
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.gameManager.GetComponent<GameManager>();

        movementSpeed = gm.obstacleSpeed;

        //Generate Operation
        if (gm.fixedTable)
        {

            firstValue = gm.table;                

        }else
        {
            firstValue = Random.Range(1 , 10);
        }

        secondValue = Random.Range(1, 10);
        operation.text = firstValue + " × " + secondValue + " = ?";

        int ran = Random.Range(0, options.Length);
        correctAnswerID = ran;
        options[ran] = firstValue * secondValue;

        int temp;
        for (int i  = 0; i < options.Length; i++)
        {
           
            if (i != ran)
            {
                    
                if (gm.fixedTable)
                {
                    do
                    {
                        options[i] = Random.Range(gm.table * 2, gm.table * 10);
                        temp = options[i];
                    } while (options[i] == options[ran]);

                }else
                {
                    do
                    {
                        options[i] = Random.Range(firstValue, firstValue * 10);
                        temp = options[i];
                    } while (options[i] == options[ran]);
                }

            }
        }

        for (int i = 0; i < options.Length; i++)
        {

            values[i].text = options[i].ToString();

        }

    }

    // Update is called once per frame
    void Update()
    {

        movementSpeed = 0.17f * gm.Clock + gm.obstacleSpeed;
        
        transform.position -= movementSpeed * Vector3.forward * Time.deltaTime;

        if (playerAnswered){

            if (correctAnswerID == gm.Player.currentPosition)
            {
                gm.Player.ship.GetComponent<Animator>().SetTrigger("win");
                gm.score++;
                gm.particles[0].Play();
            }
            else
            {
                gm.HP--;
                gm.CameraShake();
                gm.particles[1].Play();
            }


            Destroy(gameObject);

        }
    }
}
