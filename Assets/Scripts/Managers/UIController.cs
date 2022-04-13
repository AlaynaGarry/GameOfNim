using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;


    public void OnStartScene(string sceneName)
    {
        if (winUI) winUI.SetActive(false);
        if (loseUI) loseUI.SetActive(false);
        GameManager.Instance.OnLoadScene(sceneName);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
