using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

	public GameObject player;
	public GameObject HomeSpawn;
	public GameObject OfficeSpawn;
	public GameObject SchoolSpawn;
	public GameObject OfficeWorldSpawn;
	public GameObject SchoolWorldSpawn;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(HomeSpawn);
		DontDestroyOnLoad(OfficeSpawn);
		DontDestroyOnLoad(SchoolSpawn);
		DontDestroyOnLoad(OfficeWorldSpawn);
		DontDestroyOnLoad(SchoolWorldSpawn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
