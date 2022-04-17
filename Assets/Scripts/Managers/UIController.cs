using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject activeMenu;

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

    public void exitApplication()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
