using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_controller : MonoBehaviour {
	private int machine_status = 0;//0 is stop, 1 is runnig,-1 is waiting enter_input
	private GameObject DB_access;
	private GameObject PC_access;
	private GameObject EP_access;
	// Use this for initialization

	private int[] get_D_A(int flag){//flag==0, get data, flag==1, get addr
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
		if (flag == 0) {
			return Data;
		} else {
			return Addr;
		}
	}
	private int[] get_D_by_A(int[] Addr){
		return DB_access.GetComponent<Data_Base> ().get_data (Addr);
	}
	public int check_running(){//run is 1
		if (machine_status == 0) {
			return 0;
		} else {
			return 1;
		}
	}
	public void update_PC_lights(int[] Addr){
		this.GetComponentInChildren<PC_light_main_control> ().get_signal (Addr);
	}
	public void update_Instr_lights(int[] Data){
		this.GetComponentInChildren<Instr_light_main_control> ().get_signal (Data);
	}
	public void Look(){
		int[] Addr = get_D_A(1);
		int[] Data = get_D_by_A(Addr);
		if (PC_access.GetComponent<PC> ().set_PC (Addr) == 1) {
			//update PC_lights
			update_PC_lights(Addr);
			update_Instr_lights(Data);//update Instr lights
		} else {
			Debug.Log ("error set_pc");
		}
	}
	public void Load_input(){//update pc, pc light , Instr light, DB
		int[] Addr = get_D_A(1);
		int[] Data = get_D_A(0);
		if (DB_access.GetComponent<Data_Base> ().set_Memory (Addr, Data) != 1) {
			Debug.Log ("error /Main_controller/load_input");
		} else {//fine
			PC_access.GetComponent<PC> ().set_PC (Addr);//update pc
			update_PC_lights(Addr);//update pc_lights
			update_Instr_lights(Data);//update Instr lights
		}

	}


	void Start () {
		DB_access=GameObject.Find("database"); //get access to DB
		PC_access=GameObject.Find("PC"); //get access to PC
		EP_access=GameObject.Find("Execute_program"); //get access to PC
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
