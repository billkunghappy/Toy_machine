using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class run_btn : MonoBehaviour {
	public GameObject main_controller;

	// Use this for initialization
	void Start () {
		main_controller = GameObject.Find("Main_controller");//get access to main_controller
		GetComponent<Button>().onClick.AddListener(run_program);
	}

	// Update is called once per frame
	void Update () {

	}
	void run_program(){
		if(main_controller.GetComponent<Main_controller>().check_running()==0){//not running
			main_controller.GetComponent<Main_controller> ().execute ();
			Debug.Log ("press run");
		}
	}
}
