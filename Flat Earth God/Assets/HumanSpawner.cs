using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour {

	public Transform Ground;

	[Header("Spawner Attributes")]
	public GameObject HumanPrefab;
	public float SpawnInterval;
	public int MaxHumans;

	private int spawnCount;
	private float spawnTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		spawnTimer -= Time.deltaTime;
		if(spawnTimer<=0 && spawnCount<= MaxHumans)
		{
			SpawnHuman();
			spawnTimer = SpawnInterval;
		}
		
	}

	[ContextMenu("Spawn Human")]
	void SpawnHuman()
	{
		BasicMovement human =GameObject.Instantiate(HumanPrefab, Ground).GetComponent<BasicMovement>();
		GroundManager.Instance.AddHuman(human);
		spawnCount++;
	}
}
