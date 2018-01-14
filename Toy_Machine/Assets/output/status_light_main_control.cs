using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status_light_main_control : MonoBehaviour {
	Renderer[] object_ary;
	GameObject main_access;
	// Use this for initialization
	void update_light(int[] signal_ary){//signal ary[4] indicate which should be lighted
		for (int i = 0; i < 2; i++) {
			if (signal_ary [i] == 0) {
				object_ary [i].material.color = Color.gray;
			} else {
				object_ary [i].material.color = Color.green;
			}
		}
	}
	int[] signal;
	void Start () {
		object_ary = gameObject.GetComponentsInChildren<Renderer> ();//0 is inwait, 1 is ready
		main_access=GameObject.Find("Main_controller");
		signal = new int[2]{ 0, 0 };//init to gray
		update_light(signal);
	}
	
	// Update is called once per frame
	void Update () {
		if (main_access.GetComponent<Main_controller> ().get_machine_status () == 0) {
			signal [0] = 0;
			signal [1] = 1;
		} else if (main_access.GetComponent<Main_controller> ().get_machine_status () == 1) {
			signal [0] = 0;
			signal [1] = 0;
		} else {
			signal [0] = 1;
			signal [1] = 0;
		}
		update_light (signal);
	}
}
