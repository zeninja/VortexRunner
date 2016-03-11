using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public PrototypeController player;

	public GameObject[] enemies;

	public float timeBetweenEnemies = 1.5f;
	public float enemySpawnIncreaseRate = .25f;
	public float enemyWaveRate = 10;
	public float minSpawnRate = .5f;

	public GameObject characterPickup;
	float timeBetweenCharacterPickups = 15;

	// Use this for initialization
	void Start () {
		Invoke("SpawnEnemy", timeBetweenEnemies);
		Invoke("SpawnCharacterPickup", timeBetweenCharacterPickups);

		Invoke("ReduceTimeBetweenEnemies", enemyWaveRate);
	}
	
	// Update is called once per frame
	void Update () {
		CheckNumCharacters();
	}

	void SpawnEnemy() {
		GameObject enemy = Instantiate(enemies[0]) as GameObject;
		enemy.transform.position = new Vector2(Random.Range(-1, 2) * 2, transform.position.y);

		Invoke("SpawnEnemy", timeBetweenEnemies);
	}

	void ReduceTimeBetweenEnemies() {
		if(timeBetweenEnemies > minSpawnRate) {
			timeBetweenEnemies -= enemySpawnIncreaseRate;
			Invoke("ReduceTimeBetweenEnemies", enemyWaveRate);
		}
	}

	void SpawnCharacterPickup() {
		GameObject pickup = Instantiate(characterPickup) as GameObject;
		pickup.transform.position = new Vector2(Random.Range(-2, 3), transform.position.y);

		Invoke("SpawnCharacterPickup", timeBetweenCharacterPickups);
	}

	public void CheckNumCharacters() {
		if(player.numCharacters == 4) {
			CancelInvoke("SpawnCharacterPickup");
		}
	}
}
