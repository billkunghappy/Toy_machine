using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class look_btn : MonoBehaviour {
	public GameObject main_controller;//access

	// Use this for initialization
	void Start () {
		main_controller = GameObject.Find("Main_controller");//get access to main_controller
		GetComponent<Button>().onClick.AddListener(Look_input);

	}

	// Update is called once per frame
	void Update () {

	}
	void Look_input(){
		if(main_controller.GetComponent<Main_controller>().check_running()==0){//not running
			Debug.Log ("press look");
			main_controller.GetComponent<Main_controller> ().Look ();	
		}
	}
}
