﻿using UnityEngine;
using System.Collections;

public class mouseLookClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.RotateAround(transform.position, transform.up, Input.GetAxis("Mouse X"));

	}
}
