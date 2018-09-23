using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : Singleton<GroundManager> {

	public Transform GroundTransform;
	public float GroundRadius = 10;
	public float MaxRotation = 90f;

	private List<BasicMovement> humanList;

	// Use this for initialization
	protected override void Awake () {
		base.Awake();
		humanList = new List<BasicMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 centerOfGravitiy = GetCenterOfGravity();
		Debug.Log("Center of gravity: " + centerOfGravitiy);
		ApplyRotation(centerOfGravitiy);
	}

	void ApplyRotation(Vector3 centerOfGravity)
	{
		Vector3 rotationAmount=GetCenterOfGravity()*MaxRotation;

		//Need to swap X and Z to apply the proper rotation
		GroundTransform.eulerAngles=new Vector3(-rotationAmount.z,0f,-rotationAmount.x);
	}

	public void AddHuman(BasicMovement human)
	{
		humanList.Add(human);
	}

	public void RemoveHuman(BasicMovement human)
	{
		humanList.Remove(human);
	}

	public Vector3 GetCenterOfGravity()
	{
		Vector3 center = Vector3.zero;

		int humanCount = humanList.Count;
		if (humanCount > 0)
		{
			foreach (BasicMovement human in humanList)
			{
				center += human.transform.localPosition;
			}

			center.y = 0; //Just for safety
			center /= humanCount;
		}

		return center;
	}
}
