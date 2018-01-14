using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class execute_program : MonoBehaviour {
	private GameObject PC_access;
	private GameObject DB_access;
	private GameObject Main_access;

	private int[] get_data(int[] P_C){
		return Main_access.GetComponentInParent<Main_controller>().get_D_by_A(P_C);//get the data of now pc
	}
	private int[] next_P_C(int[] P_C){
		if (P_C [0] == 15 && P_C [1] == 15) {
			P_C [0] = 0;
			P_C [1] = 0;
			//can't add 1, set to [0,0]
		}
		else if (P_C [0] < 15) {
			P_C [0] += 1;
		} 
		else if(P_C [0] == 15){
			P_C [0] = 0;
			P_C [1] += 1;
		}
		return P_C;
	}
		
	public int run_program_from_begging(){
		//retrun 1 if successfully run to end, 2 need enter, 0 is error
		PC_access=GameObject.Find("PC"); //get access to PC
		DB_access=GameObject.Find("database"); //get access to PC
		Main_access=GameObject.Find("Main_controller"); //get access to PC

		int[] P_C = new int[2]{0,1};
		PC_access.GetComponent<PC> ().set_PC (P_C);//set to 1,0
		//start at 1,0
		while(P_C[0]<16&&P_C[1]<16){//usually won't auto break
			int[] data=get_data(P_C);//get the data of the P_C now
			short R_d, R_s, R_t;//REG
			R_s = DB_access.GetComponent<Data_Base> ().get_register_byid (data [1]);
			R_t = DB_access.GetComponent<Data_Base> ().get_register_byid (data [0]);
			int data_addr;
			data_addr = R_s * 16 + R_t;
			int[] data_addr_ary=new int[2];
			data_addr_ary [0] = R_t;
			data_addr_ary [1] = R_s;
			//get R_s,and R_t. may not exist
			int check_overflow;//for case 1, to

			//start
			this.GetComponentInChildren<overflow_light_main_control>().get_signal(0);//init overflow_light
			Main_access.GetComponent<Main_controller>().update_PC_lights(P_C);
			Main_access.GetComponent<Main_controller>().update_Instr_lights(data);
			//start - deal with the lights

			switch(data[3]){
			case 0://halt
				return 0;
			case 1://Add
				R_d = (short)(R_s + R_t);//mayoverflow
				check_overflow = R_s+R_t;
				if (R_d != check_overflow) {//overflow
					this.GetComponentInChildren<overflow_light_main_control> ().get_signal (1);//show overflow
				}
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
			case 2://subtract
				R_d = (short)(R_s + R_t);//mayoverflow
				check_overflow = R_s+R_t;
				if (R_d != check_overflow) {//overflow
					this.GetComponentInChildren<overflow_light_main_control> ().get_signal (1);//show overflow
				}
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
			case 3://bit and
				R_d = (short)(R_s & R_t);
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
			case 4://bit xor
				R_d = (short)(R_s ^ R_t);
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
			case 5://shift left
				R_d = (short)(R_s << R_t);
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
			case 6://shift right
				R_d = (short)(R_s >> R_t);
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
			case 7://load addr
				R_d = (short)data_addr;
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
//			case 8://load Mem[addr], may stdin
//				int[] data_get;
//				if (data_addr_ary [0] == 15 && data_addr_ary [1] == 15) {//load FF
//					
//				} else {
//					data_get = Main_access.GetComponent<Main_controller> ().get_D_by_A (data_addr_ary);
//					R_d = this.GetComponent<support_func> ().bit_4x4_to_short (data_get);
//					DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
//				}
//				break;
//			case 9://store
				

			}








			//end
			P_C=next_P_C(P_C);
			if(P_C[0]==0&&P_C[1]==0){//fail to add 1, P_C is [0,0]
				Debug.Log("over 256 memory!");
				break;
			}
		}
		return 0;


	}
}
