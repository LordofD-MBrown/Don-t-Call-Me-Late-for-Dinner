using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransitionScript : MonoBehaviour {

    GameObject dad;
    GameObject momPlatform;
    GameObject momTopDown;
    GameObject son;

	// Use this for initialization
	void Start ()
    {
        dad = GameObject.Find("Dad");
        momPlatform = GameObject.Find("Mom(Platform)");
        momTopDown = GameObject.Find("Mom(TopDown)");
        son = GameObject.Find("Son");
        momPlatform.SetActive(true);
        momTopDown.SetActive(false);
        dad.SetActive(false);
        son.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerSwitch();
    }

    void PlayerSwitch()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "HomeWorld")
        {
            momPlatform.SetActive(true);
            momTopDown.SetActive(false);
            dad.SetActive(false);
            son.SetActive(false);

        }
        else if (SceneManager.GetActiveScene().name == "Overworld")
        {
            momPlatform.SetActive(false);
            momTopDown.SetActive(true);
            dad.SetActive(false);
            son.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "WorkWorld")
        {
            Debug.Log("Here");
            momPlatform.SetActive(false);
            momTopDown.SetActive(false);
            dad.SetActive(true);
            son.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "School")
        {
            momPlatform.SetActive(false);
            momTopDown.SetActive(false);
            dad.SetActive(false);
            son.SetActive(true);
        }
    }

   
}
