using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawnerControl : MonoBehaviour {

	int randomSpawnPoint, randomBoat;
	Vector2 spawnPosition;
	public GameObject[] boats;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnBoat", 0f, 2f);
	}

	void SpawnBoat()
	{
		randomSpawnPoint = Random.Range (0, 7);
		randomBoat = Random.Range (0, boats.Length);

		switch (randomSpawnPoint) {
		case 0:
			spawnPosition = new Vector2 (-12f, 3.5f);
			Instantiate (boats[randomBoat], spawnPosition, Quaternion.identity);
			break;
		case 1:
			spawnPosition = new Vector2 (12f, 3.5f);
			Instantiate (boats[randomBoat], spawnPosition, Quaternion.identity);
			break;
		case 2:
			spawnPosition = new Vector2 (-12f, 2f);
			Instantiate (boats[randomBoat], spawnPosition, Quaternion.identity);
			break;
		case 3:
			spawnPosition = new Vector2 (12f, 2f);
			Instantiate (boats[randomBoat], spawnPosition, Quaternion.identity);
			break;
		case 4:
			spawnPosition = new Vector2 (-12f, 0f);
			Instantiate (boats[randomBoat], spawnPosition, Quaternion.identity);
			break;
		case 5:
			spawnPosition = new Vector2 (12f, 0f);
			Instantiate (boats[randomBoat], spawnPosition, Quaternion.identity);
			break;
		case 6:
			spawnPosition = new Vector2 (-12f, -1.5f);
			Instantiate (boats[randomBoat], spawnPosition, Quaternion.identity);
			break;
		case 7:
			spawnPosition = new Vector2 (12f, -1.5f);
			Instantiate (boats[randomBoat], spawnPosition, Quaternion.identity);
			break;
		}






	}
}
