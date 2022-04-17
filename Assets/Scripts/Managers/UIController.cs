using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject activeMenu;

    public string tempDifficaly;

    public string tempName1;
    public string tempName2;



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

    public void setTempName1(string name)
    {
        tempName1 = name;
    }
    public void setTempName2(string name)
    {
        tempName2 = name;
    }


}
