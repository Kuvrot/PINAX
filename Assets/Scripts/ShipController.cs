using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public int currentPosition = 1;
    public float movementSpeed = 5;
    public const float shipSpeed = 5; //This is the speed of the ship when changes it's position
    public Transform[] positions;
    public GameObject ship;

    // up and down animation
    protected bool canMove = true;
    protected float interpolation = 0f;
    protected bool vertical = true;

    //Components
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = ship.GetComponent<Animator>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {

            Move(-1);

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Joystick1Button5))
        {

            Move(1);

        }

        if (vertical)
        {
            interpolation -= 1 * Time.deltaTime;

            if (interpolation <= -0.35f)
            {
                vertical = false;
            }
        }else
        {
            interpolation += 1 * Time.deltaTime;

            if (interpolation >= 0.35f)
            {
                vertical = true;
            }
        }

        ship.transform.position = Vector3.Lerp(
            ship.transform.position, 

            new Vector3(
                positions[currentPosition].position.x , 
                ship.transform.position.y + interpolation, 
                ship.transform.position.z), 

            shipSpeed * Time.deltaTime);
    }

    IEnumerator InputCoolDown(int dir) //dir is the horizontal direction
    {

        if (canMove)
        {

            if (dir == -1)
            {
                
                anim.SetTrigger("left");
                yield return new WaitForSeconds(0.1f);
                if (currentPosition > 0)
                {
                    currentPosition--;
                }

            }
            else if (dir == 1)
            {
                anim.SetTrigger("right");
                yield return new WaitForSeconds(0.1f);
                if (currentPosition  < positions.Length - 1)
                {
                    currentPosition++;
                }

            }

            canMove = false;
        }
            

        //yield return new WaitForSeconds(0.2f);


        canMove = true;
       
        StopAllCoroutines();
    }

    public void Move(int dir)
    {

        StartCoroutine(InputCoolDown(dir));

    }

}
