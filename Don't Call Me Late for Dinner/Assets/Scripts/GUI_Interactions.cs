using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI_Interactions : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Avery - Test Scene");
    }
}
