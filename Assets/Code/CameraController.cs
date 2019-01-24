using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private GameObject PlayerObject;

	/// <summary>
	/// a scale of (.5, 1, -.5) will center the player in the camera
	/// </summary>
	private Vector3 Offset = new Vector3(.5f, 1f,-.5f) * 11;

	/// <summary>
	/// will move the camera to track the player
	/// </summary>
	void Update()
    {
		transform.position = PlayerObject.transform.position + Offset;
	}
}
