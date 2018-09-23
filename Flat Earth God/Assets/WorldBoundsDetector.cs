using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBoundsDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerExit(Collider other)
	{
		BasicMovement movement = other.GetComponent<BasicMovement>();

		if(movement!=null)
		{
			movement.StartFalling();
		}

	}

}
