using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{

    [Header("Spaceship selector")]
    public int shipIndex = 0;
    public GameObject[] shipViewModels;
    public int[] shipCost;
    public Text shipCostUI;
    public Transform expo_rotation;

    [Header("Buy/Select buttons")]
    public GameObject select;
    public GameObject buy;

    private MenuManager menuManager;

    [Header("Ship player will use")]
    public int selectedShip;

    // Start is called before the first frame update
    void Start()
    {
        menuManager = GetComponent<MenuManager>();

       if (PlayerPrefs.HasKey("Second"))
        {
            shipCost[1] = 0;
        }

        if (PlayerPrefs.HasKey("Third"))
        {
            shipCost[2] = 0;
        }

        ChangeShip();
    }

    // Update is called once per frame
    void Update()
    {

        expo_rotation.Rotate(0 , 25 *Time.deltaTime , 0);

    }

    private void ChangeShip ()
    {
        if (shipIndex >= shipViewModels.Length)
        {
            shipIndex = 0;
        }

        if (shipIndex < 0)
        {
            shipIndex = shipViewModels.Length - 1;
        }

        foreach (GameObject spaceship in shipViewModels)
        {
            spaceship.SetActive(false);
        }

        if (shipCostUI != null) {

            if (shipCost[shipIndex] == 0)
            {
                if (shipIndex == selectedShip)
                {
                    if (!MenuManager.languageChange)
                    {
                        shipCostUI.text = "SELECCIONADA";
                    }
                    else
                    {
                        shipCostUI.text = "SELECTED";
                    }
                }
                else
                {
                    if (!MenuManager.languageChange)
                    {
                        shipCostUI.text = "YA LO TIENES";
                    }
                    else
                    {
                        shipCostUI.text = "ALREADY OWNED";
                    }
                }
                select.SetActive(true);
                buy.SetActive(false);
            }
            else
            {
                shipCostUI.text = "$" + shipCost[shipIndex].ToString();
                select.SetActive(false);
                buy.SetActive(true);
            }
        }

        shipViewModels[shipIndex].SetActive(true);
    }

    public void Right()
    {
        shipIndex++;
        ChangeShip();
    }

    public void Left()
    {
        shipIndex--;
        ChangeShip();
    }

    public void Buy()
    {
        if (menuManager.playerMoney >= shipCost[shipIndex])
        {
            menuManager.playerMoney -= shipCost[shipIndex];
            shipCost[shipIndex] = 0;
            
            if (shipIndex == 1)
            {
                PlayerPrefs.SetInt("Second" , 1);
            }

            if (shipIndex == 2)
            {
                PlayerPrefs.SetInt("Third", 1);
            }

            ChangeShip();
        }
    }

    public void Select()
    {
        selectedShip = shipIndex;
        PlayerPrefs.SetInt("SelectedShip" , selectedShip);
        ChangeShip();
    }
}
