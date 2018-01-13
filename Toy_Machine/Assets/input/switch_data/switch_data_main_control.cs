using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switch_data_main_control : MonoBehaviour {
	public int[] Data_status=new int[16];//init to zero
	public Button[] sixteen_switches;
	// Use this for initialization
	public int[] get_signal(){
		return Data_status;
	}
	void Start () {
		sixteen_switches = GetComponentsInChildren<Button> ();
		int count = 0;
		foreach (Button the_switch in sixteen_switches) {
			the_switch.GetComponent<switch_data_each>().which_switch = count;
			count+=1;
		}//assign all switches
	}

	// Update is called once per frame
	void Update () {
		
	}
}
