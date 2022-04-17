using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject activeMenu;

    public string tempDifficaly;




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

    public void setTempDif(string dif)
    {
        tempDifficaly = dif;
        Debug.Log(tempDifficaly);
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
