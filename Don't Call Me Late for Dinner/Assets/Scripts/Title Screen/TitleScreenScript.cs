using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    GameObject intro;
    GameObject mainMenu;

    private void Start()
    {
        intro = GameObject.Find("Introduction");
        mainMenu = GameObject.Find("Title Screen");
        intro.SetActive(false);
    }

    public void Introduction()
    {
        intro.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("HomeWorld");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
