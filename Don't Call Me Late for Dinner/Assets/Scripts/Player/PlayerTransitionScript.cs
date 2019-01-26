using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTransitionScript : MonoBehaviour {

    GameObject dad;
    GameObject mom;
    GameObject son;

	// Use this for initialization
	void Start ()
    {
        dad = GameObject.Find("Dad");
        mom = GameObject.Find("Mom");
        son = GameObject.Find("Son");
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerSwitch();
    }

    void PlayerSwitch()
    {
        if (SceneManager.GetActiveScene().name == "HomeWorld")
        {
            mom.SetActive(true);
            dad.SetActive(false);
            son.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Nathan - Test Scene")
        {
            mom.SetActive(true);
            dad.SetActive(false);
            son.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "WorkWorld")
        {
            mom.SetActive(false);
            dad.SetActive(true);
            son.SetActive(false);
        }
    }

   
}
