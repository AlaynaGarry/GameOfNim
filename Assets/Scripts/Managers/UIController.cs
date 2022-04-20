using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject activeMenu;

    [SerializeField] TMP_InputField numberOfRowsField;
    [SerializeField] TMP_InputField topRowCountField;

    public string tempDifficaly;

    public enum Dif
    {
        EASY = 0,
        MEDIUM = 1,
        HARD = 2
    }


    public void OnStartScene(string sceneName)
    {

        GameManager.Instance.OnLoadScene(sceneName);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void ToggleMenu(GameObject menu)
    {
        activeMenu.SetActive(false);
        menu.SetActive(true);
        activeMenu = menu;
    }

    public void setTempDif(int dif)
    {
        Dif actualDif = (Dif)dif;
        switch (actualDif)
        {
            case Dif.EASY:
                numberOfRowsField.text = "3";
                topRowCountField.text = "1";
                break;
            case Dif.MEDIUM:
                numberOfRowsField.text = "4";
                topRowCountField.text = "1";
                break;
            case Dif.HARD:
                numberOfRowsField.text = "5";
                topRowCountField.text = "3";
                break;
            default:
                break;
        }
    }

    public void checkDif()
    {
        GameObject rows = GameObject.Find("RowsInput");
        GameObject count = GameObject.Find("TopRowInput");
        int r = int.Parse(rows.GetComponent<TMP_InputField>().text);
        int c = int.Parse(count.GetComponent<TMP_InputField>().text);
        GameManager.ChangeDifficulty(r, c);
       

        /*if(tempDifficaly == "easy")
        {
            GameManager.Instance.ChangeDifficulty(3, 1);
        }
        else if(tempDifficaly == "Medium")
        {
            GameManager.Instance.ChangeDifficulty(5, 1);
        }
        else if(tempDifficaly == "Hard")
        {
            GameManager.Instance.ChangeDifficulty(9, 1);
        }*/
    }


}
