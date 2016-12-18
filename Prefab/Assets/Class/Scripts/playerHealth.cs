using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (currentHealth <= 0) {

			//Destroy (gameObject);
			SceneManager.LoadScene(0);
		}
	
	}

	void OnCollsionEnter(Collision col) {

		if (col.gameObject.tag == "enemy") {

			currentHealth -= col.gameObject.GetComponent<EnemyClass>().damage; 

		}
	}
}
