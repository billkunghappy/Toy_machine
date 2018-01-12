using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class display_7_2_control : MonoBehaviour {
	// Use this for initialization
	Renderer[] object_ary;

	//global var is above

	void update_light(int[] signal_ary){//signal ary[7] indicate which should be lighted
		for (int i = 0; i < 7; i++) {
			if (signal_ary [i] == 1) {
				object_ary [i].material.color = Color.yellow;
			} else {
				object_ary [i].material.color = Color.black;
			}
		}
	}
	public void get_signal(int main_signal){//main_signal is a num from 0~15 and -1(this is reset)
		int[] signal_send;
		switch (main_signal) {
		case -1://reset
			signal_send = new int[7]{ 0, 0, 0, 0, 0, 0, 0 };
			update_light (signal_send);
			break;
		case 0:
			signal_send = new int[7]{ 1, 1, 1, 1, 1, 1, 0 };
			update_light (signal_send);
			break;
		case 1:
			signal_send = new int[7]{ 0, 1, 1, 0, 0, 0, 0 };
			update_light (signal_send);
			break;
		case 2:
			signal_send = new int[7]{ 1, 1, 0, 1, 1, 0, 1 };
			update_light (signal_send);
			break;
		case 3:
			signal_send = new int[7]{ 1, 1, 1, 1, 0, 0, 1 };
			update_light (signal_send);
			break;
		case 4:
			signal_send = new int[7]{ 0, 1, 1, 0, 0, 1, 1 };
			update_light (signal_send);
			break;
		case 5:
			signal_send = new int[7]{ 1, 0, 1, 1, 0, 1, 1 };
			update_light (signal_send);
			break;
		case 6:
			signal_send = new int[7]{ 1, 0, 1, 1, 1, 1, 1 };
			update_light (signal_send);
			break;
		case 7:
			signal_send = new int[7]{ 1, 1, 1, 0, 0, 0, 0 };
			update_light (signal_send);
			break;
		case 8:
			signal_send = new int[7]{ 1, 1, 1, 1, 1, 1, 1 };
			update_light (signal_send);
			break;
		case 9:
			signal_send = new int[7]{ 1, 1, 1, 0, 0, 1, 1 };
			update_light (signal_send);
			break;
		case 10://A
			signal_send = new int[7]{ 1, 1, 1, 0, 1, 1, 1 };
			update_light (signal_send);
			break;
		case 11://B
			signal_send = new int[7]{ 0, 0, 1, 1, 1, 1, 1 };
			update_light (signal_send);
			break;
		case 12://C
			signal_send = new int[7]{ 1, 0, 0, 1, 1, 1, 0 };
			update_light (signal_send);
			break;
		case 13://D
			signal_send = new int[7]{ 0, 1, 1, 1, 1, 0, 1 };
			update_light (signal_send);
			break;
		case 14://E
			signal_send = new int[7]{ 1, 0, 0, 1, 1, 1, 1 };
			update_light (signal_send);
			break;
		case 15://F
			signal_send = new int[7]{ 1, 0, 0, 0, 1, 1, 1 };
			update_light (signal_send);
			break;
		}
	}
	void Start () {
		object_ary = gameObject.GetComponentsInChildren<Renderer> ();
		//get object ary
		get_signal (-1);
		//reset to black
	}

	// Update is called once per frame
	void Update () {
		//the whole Update() is for debug
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
		if (Input.GetKeyDown ("r")) {
			get_signal (-1);
		}

	}

}
