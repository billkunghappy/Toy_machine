﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instr_light_main_control : MonoBehaviour {
	public void get_signal(int[] main_signal){//four num from 0 to 15
		gameObject.GetComponentInChildren<Instr_light_dig0_control>().get_signal(main_signal[0]);
		gameObject.GetComponentInChildren<Instr_light_dig1_control>().get_signal(main_signal[1]);
		gameObject.GetComponentInChildren<Instr_light_dig2_control>().get_signal(main_signal[2]);
		gameObject.GetComponentInChildren<Instr_light_dig3_control>().get_signal(main_signal[3]);
	}
	// Use this for initialization
	void Start () {

	}
		
}
