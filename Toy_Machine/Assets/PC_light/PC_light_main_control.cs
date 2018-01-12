using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_light_main_control : MonoBehaviour {
	public void get_signal(int[] main_signal){//two num from 0 to 15
		gameObject.GetComponentInChildren<PC_light_dig0_control>().get_signal(main_signal[0]);
		gameObject.GetComponentInChildren<PC_light_dig1_control>().get_signal(main_signal[1]);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//test
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			//test
			int[] test=new int[2]{1,2};
			get_signal (test);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			//test
			int[] test=new int[2]{15,14};
			get_signal (test);
		}
	}
}
