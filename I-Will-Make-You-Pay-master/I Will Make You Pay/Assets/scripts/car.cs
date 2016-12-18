using UnityEngine;
using System.Collections;

public class car : MonoBehaviour {
	
	public float value;
	public float maxHealth;
	public float currentHealth;

	public float damage;
	public Vector3 direction;
	public float speed = 3; 

	void Start () {
		
		currentHealth = maxHealth;

	}
	
	void Update () {
		
		transform.Translate(Vector3.forward * Time.deltaTime * speed);

	}

	void OnCollisionEnter(Collision col) {
		
		if (col.gameObject.tag == "Untagged" || col.gameObject.tag == "p2" || col.gameObject.tag == "Finish")
		{
			Destroy(gameObject);
		}

		if (col.gameObject.tag == "p1")
		{
			currentHealth -= col.gameObject.GetComponent<car>().damage;
		}

		else if (col.gameObject.tag == "p2")
		{
			currentHealth -= col.gameObject.GetComponent<car>().damage;
		}

		if (currentHealth <= 0)
		{
			if (col.gameObject.tag == "p1")
			{
				system.main.funds1 -= value;
			}
			else if (col.gameObject.tag == "p2")
			{
				system.main.funds2 -= value;
			}
			system.main.bu = true;
			Destroy(gameObject);
		}
	}
}
