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
		int[] init_signal = new int[2]{ 0, 1 };
		get_signal (init_signal);
	}
		
}