using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBuilder : MonoBehaviour
{
	public GameObject floor;

	[SerializeField]
	private GameObject PlayerObject;

	//IMPORTANT: Make sure that the level Prefab is SQUARE & ODD NUMBERS!!!!!!!!!!!!
	private int FloorWidth { get { return (int)floor.transform.localScale.x; } }

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		var playerX = PlayerObject.transform.position.x % FloorWidth;
		var playerZ = PlayerObject.transform.position.z % FloorWidth;

		int x, z;

		if (Math.Abs(playerX) > 4.5f || Math.Abs(playerZ) > 4.5f)
		{
			x = (int)PlayerObject.transform.position.x / 9;
			z = (int)PlayerObject.transform.position.z / 9;
		}
	}
}
