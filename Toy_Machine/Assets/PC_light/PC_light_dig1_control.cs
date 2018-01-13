using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_light_dig1_control : MonoBehaviour {
	Renderer[] object_ary;
	// Use this for initialization

	void update_light(int[] signal_ary){//signal ary[4] indicate which should be lighted
		for (int i = 0; i < 4; i++) {
			if (signal_ary [i] == 1) {
				object_ary [i].material.color = Color.green;
			} else {
				object_ary [i].material.color = Color.gray;
			}
		}
	}
	public void get_signal(int main_signal){//a digit from 0~16
		update_light(gameObject.GetComponent<convert_signal>().light_convert16(main_signal));
	}

	void Start () {
		object_ary = gameObject.GetComponentsInChildren<Renderer> ();
		//get four light's renderer
		get_signal(0);//all black

	}

	// Update is called once per frame
	void Update () {
		//test
		if (Input.GetKeyDown ("0")) {
			get_signal (0);
		}
		if (Input.GetKeyDown ("1")) {
			get_signal (1);
		}
		if (Input.GetKeyDown ("2")) {
			get_signal (2);
		}
		if (Input.GetKeyDown ("3")) {
			get_signal (3);
		}
		if (Input.GetKeyDown ("4")) {
			get_signal (4);
		}
		if (Input.GetKeyDown ("5")) {
			get_signal (5);
		}
		if (Input.GetKeyDown ("6")) {
			get_signal (6);
		}
		if (Input.GetKeyDown ("7")) {
			get_signal (7);
		}
		if (Input.GetKeyDown ("8")) {
			get_signal (8);
		}
		if (Input.GetKeyDown ("9")) {
			get_signal (9);
		}
		if (Input.GetKeyDown ("a")) {
			get_signal (10);
		}
		if (Input.GetKeyDown ("b")) {
			get_signal (11);
		}
		if (Input.GetKeyDown ("c")) {
			get_signal (12);
		}
		if (Input.GetKeyDown ("d")) {
			get_signal (13);
		}
		if (Input.GetKeyDown ("e")) {
			get_signal (14);
		}
		if (Input.GetKeyDown ("f")) {
			get_signal (15);
		}

	}
}
