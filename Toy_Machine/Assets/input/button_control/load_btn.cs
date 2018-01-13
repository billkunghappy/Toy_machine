using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class load_btn : MonoBehaviour {
	public GameObject main_controller;

	// Use this for initialization
	void Start () {
		main_controller = GameObject.Find("Main_controller");//get access to main_controller
		GetComponent<Button>().onClick.AddListener(Load_input);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Load_input(){
		if(main_controller.GetComponent<Main_controller>().check_running()==0){//not running
			main_controller.GetComponent<Main_controller> ().load_input ();
			Debug.Log ("press load");
		}
	}
}
