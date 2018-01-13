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
		
}
