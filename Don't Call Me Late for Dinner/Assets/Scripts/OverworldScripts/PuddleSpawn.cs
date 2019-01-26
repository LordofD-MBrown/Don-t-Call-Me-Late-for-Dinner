using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleSpawn : MonoBehaviour {

	public GameObject MudSprite;
	private int puddleNum = 5;
	public List<Vector3> puddle = new List<Vector3>();
	

	// Use this for initialization
	void Awake () 
	{
		puddleInstantiate();
		puddlePlacement();
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}
	
	void puddleInstantiate()
	{
		
		for (int i = 0; i < puddleNum; i++)
			puddle.Add(new Vector3(Random.Range(0f, 25f), Random.Range(-25f, 0f), 0f));
				
	}
	
	void puddlePlacement()
	{
		for (int i = 0; i < puddleNum; i++)
		{
			GameObject instance = Instantiate(MudSprite) as GameObject;
			instance.transform.position = new Vector3(puddle[i].x, puddle[i].y, 0f);
			instance.AddComponent<BoxCollider2D>();
			instance.transform.SetParent(GameObject.Find("mudSpawner").transform);
		}
	}
}

