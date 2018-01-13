using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_controller : MonoBehaviour {
	private int machine_status = 0;//0 is stop, 1 is runnig
	private GameObject DB_access;
	private GameObject PC_access;
	// Use this for initialization

	public int check_running(){//run is 1
		if (machine_status == 0) {
			return 0;
		} else {
			return 1;
		}
	}
	private void update_PC_lights(int[] Addr){
		this.GetComponentInChildren<PC_light_main_control> ().get_signal (Addr);
	}
	public void Look(){
		int[,] input_addr;
		input_addr = gameObject.GetComponentInChildren<switch_addr_main_control> ().get_signal ();//[2,4] bit
		int[] Addr = new int[2];
		for (int i = 0; i < 2; i++) {
			Addr[i] = this.GetComponent<support_func> ().four_bit_convert (input_addr [i,0],input_addr [i,1],input_addr [i,2],input_addr [i,3]);
		}//get Addr as two int(_16)
		if (PC_access.GetComponent<PC> ().set_PC (Addr) == 1) {
			//update PC_lights
			update_PC_lights(Addr);
		} else {
			Debug.Log ("error set_pc");
		}
	}
	public void Load_input(){
		int[,] input_addr,input_data;
		input_addr = gameObject.GetComponentInChildren<switch_addr_main_control> ().get_signal ();//[2,4] bit
		input_data = gameObject.GetComponentInChildren<switch_data_main_control> ().get_signal ();//[4,4]
		int[] Addr = new int[2];
		int[] Data = new int[4];
		for (int i = 0; i < 2; i++) {
			Addr[i] = this.GetComponent<support_func> ().four_bit_convert (input_addr [i,0],input_addr [i,1],input_addr [i,2],input_addr [i,3]);
		}
		for (int i = 0; i < 4; i++) {
			Data[i] = this.GetComponent<support_func> ().four_bit_convert (input_data [i,0],input_data [i,1],input_data [i,2],input_data [i,3]);
		}
		if (DB_access.GetComponent<Data_Base> ().set_Memory (Addr, Data)!=1) {
			Debug.Log ("error /Main_controller/load_input");
		}

	}
	void Main_progress(){
		//progress here
	}

	void Start () {
		DB_access=GameObject.Find("database"); //get access to DB
		PC_access=GameObject.Find("PC"); //get access to PC
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
