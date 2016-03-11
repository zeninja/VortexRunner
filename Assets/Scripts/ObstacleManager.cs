using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

	public PlayerManager playerManager;

	float spawnRate = 2;
	public float spawnDecayRate = .2f;
	float minSpawnRate = 1f;
	
	public GameObject obstaclePrefab;
	public Vector3[] lanePositions;

	// Use this for initialization
	void Start () {
		Invoke("SpawnObstacles", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void SpawnObstacles() {
		GameObject obstacle = Instantiate(obstaclePrefab) as GameObject;
		obstacle.transform.position = lanePositions[Random.Range(0, lanePositions.Length)];
		obstacle.GetComponent<Obstacle>().playerManager = playerManager;
		
		Invoke("SpawnObstacles", spawnRate);
		spawnRate -= spawnDecayRate;
		spawnRate = Mathf.Max(spawnRate, minSpawnRate);
	}
}
