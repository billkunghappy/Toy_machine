using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display7_3_control : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			gameObject.GetComponentInChildren<display_73_A>().light_on("Cube(A)",1);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			gameObject.GetComponentInChildren<display_73_A>().light_on("Cube(A)",0);
		}
			
	}
}