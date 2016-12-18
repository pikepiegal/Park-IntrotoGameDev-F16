using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {

	public bulletClass bullet; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)){
			Shoot();
		}
	}

	void Shoot() {

		bullet.direction = transform.forward; 
		//create a bullet at our position with a rotation 
		Instantiate(bullet, transform.position + transform.forward, transform.rotation);

	}
}
