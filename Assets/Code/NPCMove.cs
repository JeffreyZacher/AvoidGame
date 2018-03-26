using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
	[SerializeField]
	private Transform _destination;

	public NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start ()
	{
		_navMeshAgent = this.GetComponent<NavMeshAgent>();

		if(_navMeshAgent == null)
		{
			Debug.Log("Nav Mesh agent is not attached to " + gameObject.name);
		}
	}

	private void Update()
	{
		Vector3 targetVector = _destination.transform.position;
		_navMeshAgent.SetDestination(targetVector);
	}
}
