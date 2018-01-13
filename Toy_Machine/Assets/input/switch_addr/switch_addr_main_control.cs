using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switch_addr_main_control : MonoBehaviour {
	public int[] Addr_status=new int[8]{0,0,0,0,0,0,0,0};//init to zero
	public Button[] eight_switches;
	// Use this for initialization
	public int[,] get_signal(){
		int count = 0;
		int[,] return_ary = new int[2,4];
		for (int i = 0; i < 2; i++) {
			for(int j=0;j<4;j++){
				return_ary[i,j]=Addr_status[count];
				count+=1;
			}
		}
		return return_ary;
	}
	void Start () {
		eight_switches = GetComponentsInChildren<Button> ();
		int count = 0;
		foreach (Button the_switch in eight_switches) {
			the_switch.GetComponent<switch_addr_each>().which_switch = count;
			count+=1;
		}//assign all switches
	}
	
	// Update is called once per frame
	void Update () {
		//for debug
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Debug.Log(Addr_status[0]);
		}
	}
}
