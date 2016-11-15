using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private  Transform myTransform;

	public float moveSpeed 

	Vector3 forward; 

	// Use this for initialization
	void Start () {

		myTransform = GetComponent<Transform> ();

		//myTransform.position.x += 5;

		//z-axis is forward vector
		//forward = new Vector3(0,0,1);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			
			//myTransform.position += forward; 
			myTransform.position += transform.forward;
		}

		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {

			//no backward or left shortcut in unity. shame. subtract the vectors to go the other direction
			myTransform.position -= transform.forward;
		}

		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {

			myTransform.position += transform.right;
		}

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {

			//no backward or left shortcut in unity. shame. subtract the vectors to go the other direction
			myTransform.position -= transform.right;
		}
	}
}
