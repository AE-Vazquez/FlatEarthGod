using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

	
	public float MoveSpeed = 1f;

	public float DirectionChangeInterval = 2f;

	private bool isFalling;

	private float directionChangeTimer;

	private Vector3 movingDirection;

	public Transform cachedTransorm
	{
		get;private set;
	}

	private void Awake()
	{
		cachedTransorm = transform;
	}
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update ()
	{
		if (isFalling)
		{
			movingDirection = Vector3.down;
		}
		else
		{
			directionChangeTimer -= Time.deltaTime;
			if(directionChangeTimer<=0)
			{
				movingDirection = GetRandomDirection();
				directionChangeTimer = DirectionChangeInterval;
			}
		}

		Vector3 movementVector = movingDirection*Time.deltaTime*MoveSpeed;

		MoveToDirection(movementVector);
	}

	void MoveToDirection(Vector3 movementVector)
	{
		cachedTransorm.localPosition += movementVector;
	}

	public void StartFalling()
	{
		cachedTransorm.SetParent(null);
		GroundManager.Instance.RemoveHuman(this);
		isFalling = true;
		Destroy(gameObject, 4);
	}

	public Vector3 GetRandomDirection()
	{
		Vector3 dir = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
		return dir.normalized;
	}
}
