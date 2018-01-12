using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display7_3_control : MonoBehaviour {
	// Use this for initialization
	public GameObject[] bars = new GameObject[10];
	void getchild (){
		print ("test test1");
		bars = this.gameObject.transform.GetComponentsInChildren<GameObject>();
	}
	void Start () {
		print ("test test");
		getchild ();
		print ("hi");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
