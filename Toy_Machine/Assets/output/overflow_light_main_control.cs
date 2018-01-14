using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overflow_light_main_control : MonoBehaviour {

	// Use this for initialization
	public void get_signal(int signal){//1 is light
		if(signal==1){
			gameObject.GetComponent<Renderer> ().material.color = Color.red;//set to red
		}else{
			gameObject.GetComponent<Renderer> ().material.color = Color.gray;//set to gray
		}
	}
	void Start () {
		get_signal (0);//init to gray	
	}

}
