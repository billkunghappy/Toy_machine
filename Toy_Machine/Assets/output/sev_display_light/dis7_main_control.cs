using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dis7_main_control : MonoBehaviour {
	public void get_signal(int[] main_signal){//four num from -1 to 15
		gameObject.GetComponentInChildren<display_7_0_control>().get_signal(main_signal[0]);
		gameObject.GetComponentInChildren<display_7_1_control>().get_signal(main_signal[1]);
		gameObject.GetComponentInChildren<display_7_2_control>().get_signal(main_signal[2]);
		gameObject.GetComponentInChildren<display7_3_control>().get_signal(main_signal[3]);
	}

}
