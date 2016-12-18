using UnityEngine;
using System.Collections;

public class GameManagerClass : MonoBehaviour {

	public EnemyClass basicEnemy;
	public EnemyClass toughEnemy;

	public Transform player; 

	public Transform[] spawnPoints;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(){

		//randomly spawn basic or tough enemy
		float rand = Random.Range (0.0f, 1.0f);

		//20% chance spawn difficult enemy
		if (rand < .2f) {

			toughEnemy.target = player;
			Instantiate (toughEnemy, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);

		} else {

			toughEnemy.target = player; 
			Instantiate (basicEnemy, spawnPoints [Random.Range (0, spawnPoints.Length)].position, Quaternion.identity);
		}
}
