using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SchoolObstacles : MonoBehaviour
{

    GameObject player;
    GameObject son;

    public Vector3 startingPosition = new Vector3 (222f, 11f, -10.10769f);
    Vector3 sonStartingPosition = Vector3.zero;

    // Use this for initialization
    void Awake()
    {
        // subscribe to new scene loaded event
        SceneManager.sceneLoaded += OnSchoolSceneLoaded;

        player = GameObject.Find("Player");
        son = GameObject.Find("Son");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Collides with Bully
        
    }

    void OnSchoolSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "School")
        {
            // set the starting position
            ResetSchoolStartPosition();
            // get starting position of Son
            sonStartingPosition = son.transform.position;
        }
        else
        {
            // reset son starting position to zero
            sonStartingPosition = Vector3.zero;
        }
    }

    private void ResetSchoolStartPosition()
    {
        // set player starting position
        player.transform.position = startingPosition;
        // if son starting position has been set, reset son position
        if (Vector3.zero != sonStartingPosition)
        {
            son.transform.position = sonStartingPosition;
        }
    }
}
