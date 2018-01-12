using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_light_dig0_control : MonoBehaviour {
	Renderer[] object_ary;
	// Use this for initialization

	void update_light(int[] signal_ary){//signal ary[4] indicate which should be lighted
		for (int i = 0; i < 4; i++) {
			if (signal_ary [i] == 1) {
				object_ary [i].material.color = Color.yellow;
			} else {
				object_ary [i].material.color = Color.gray;
			}
		}
	}
	public void get_signal(int main_signal){//a digit from 0~16
		int[] signal_send;
		switch (main_signal) {
			case 0:
				signal_send = new int[4]{ 0, 0, 0, 0 };
				update_light (signal_send);
				break;
			case 1:
				signal_send = new int[4]{ 0, 0, 0, 1 };
				update_light (signal_send);
				break;
			case 2:
				signal_send = new int[4]{ 0, 0, 1, 0 };
				update_light (signal_send);
				break;
			case 3:
				signal_send = new int[4]{ 0, 0, 1, 1 };
				update_light (signal_send);
				break;
			case 4:
				signal_send = new int[4]{ 0, 1, 0, 0 };
				update_light (signal_send);
				break;
			case 5:
				signal_send = new int[4]{ 0, 1, 0, 1 };
				update_light (signal_send);
				break;
			case 6:
				signal_send = new int[4]{ 0, 1, 1, 0 };
				update_light (signal_send);
				break;
			case 7:
				signal_send = new int[4]{ 0, 1, 1, 1 };
				update_light (signal_send);
				break;
			case 8:
				signal_send = new int[4]{ 1, 0, 0, 0 };
				update_light (signal_send);
				break;
			case 9:
				signal_send = new int[4]{ 1, 0, 0, 1 };
				update_light (signal_send);
				break;
			case 10:
				signal_send = new int[4]{ 1, 0, 1, 0 };
				update_light (signal_send);
				break;
			case 11:
				signal_send = new int[4]{ 1, 0, 1, 1 };
				update_light (signal_send);
				break;
			case 12:
				signal_send = new int[4]{ 1, 1, 0, 0 };
				update_light (signal_send);
				break;
			case 13:
				signal_send = new int[4]{ 1, 1, 0, 1 };
				update_light (signal_send);
				break;
			case 14:
				signal_send = new int[4]{ 1, 1, 1, 0 };
				update_light (signal_send);
				break;
			case 15:
				signal_send = new int[4]{ 1, 1, 1, 1 };
				update_light (signal_send);
				break;
		}

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
