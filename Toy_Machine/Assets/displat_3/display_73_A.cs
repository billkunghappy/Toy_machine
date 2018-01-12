using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_73_A : MonoBehaviour {

	// Use this for initialization
	public void light_on (string object_name,int a){
		GameObject the_object = GameObject.Find (object_name);
		if (a == 0) {
			the_object.GetComponent<Renderer>().material.color = Color.black;
		}
		else if (a == 1) {
			the_object.GetComponent<Renderer>().material.color = Color.yellow;
		}
	}

	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}