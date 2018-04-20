using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed;

	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

		//Move "left"/"right"
		transform.Translate(x/2, 0, x/2);

		//Move "up"/"down"
		transform.Translate(-z/2, 0, z/2);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy" )
		{
			transform.Translate(0, 3f, 0);
			FindObjectOfType<AudioManager>().Play("Wow");
		}
	}
}
