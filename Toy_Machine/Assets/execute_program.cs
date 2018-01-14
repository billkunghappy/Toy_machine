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
	public bool game_running;

	public void run_program_from_begging(){
		PC_access=GameObject.Find("PC"); //get access to PC
		DB_access=GameObject.Find("database"); //get access to PC
		Main_access=GameObject.Find("Main_controller"); //get access to PC
		game_running = true;
		Main_access.GetComponent<Main_controller> ().change_machine_status(1);
		StartCoroutine(Lets_run());
	}

	public bool isEnter=false;//init to zero
	IEnumerator Lets_run(){
		//retrun 1 if successfully run to end, 2 need enter, 0 is error
		int[] P_C = new int[2]{0,1};
		PC_access.GetComponent<PC> ().set_PC (P_C);//set to 1,0
		//start at 1,0
		while(game_running && P_C[1]>0){//usually won't auto break
			int[] data=get_data(P_C);//get the data of the P_C now
			short R_d, R_s, R_t;//REG
			R_s = DB_access.GetComponent<Data_Base> ().get_register_byid (data [1]);
			R_t = DB_access.GetComponent<Data_Base> ().get_register_byid (data [0]);
			int data_addr;
			data_addr = data [1] * 16 + data [0];
			int[] data_addr_ary=new int[2];
			data_addr_ary [0] = data [0];
			data_addr_ary [1] = data [1];
			Debug.Log ("pc is "+P_C[1]+" "+P_C[0]);
			//get R_s,and R_t. may not exist
			int check_overflow;//for case 1, to

			//start
			this.GetComponentInChildren<overflow_light_main_control>().get_signal(0);//init overflow_light
			Main_access.GetComponent<Main_controller>().update_PC_lights(P_C);
			Main_access.GetComponent<Main_controller>().update_Instr_lights(data);
			//start - deal with the lights

			switch(data[3]){
			case 0://halt
				game_running = false;
				break;
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
			case 8://load Mem[addr], may stdin
				int[] data_8;
				if (data_addr_ary [0] == 15 && data_addr_ary [1] == 15) {//load FF
					isEnter=true;
					while(isEnter){
						//do nothing but wait
						yield return new WaitForSeconds((float)0.3);//check every 0.3 second
					}
					data_8 = Main_access.GetComponent<Main_controller> ().get_D_A (0);//get now input
				} else {
					data_8 = Main_access.GetComponent<Main_controller> ().get_D_by_A (data_addr_ary);
				}
				R_d = this.GetComponent<support_func> ().bit_4x4_to_short (data_8);
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
			case 9://store
				int[] data_9;
				R_d = DB_access.GetComponent<Data_Base> ().get_register_byid (data [2]);
				if (data_addr_ary [0] == 15 && data_addr_ary [1] == 15) {//stdout
					int[] data_7dis = GetComponent<support_func> ().short_to_bit_4x4 (R_d);
					Main_access.GetComponent<Main_controller> ().update_7display (data_7dis);
				} else {
					data_9= GetComponent<support_func>().short_to_bit_4x4(R_d);
					DB_access.GetComponent<Data_Base> ().set_Memory (data_addr_ary,data_9);//set register
				}
				break;
			case 10://HAS BUG 
				int[] addr_10 = new int[2];
				int[] R_t_in4 = new int[4];
				R_t_in4 = GetComponent<support_func> ().short_to_bit_4x4 (R_t);
				addr_10 [0] = R_t_in4 [0];
				addr_10 [1] = R_t_in4 [1];
				int[] data_10 = Main_access.GetComponent<Main_controller> ().get_D_by_A (addr_10);
				R_d = this.GetComponent<support_func> ().bit_4x4_to_short (data_10);
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				break;
			case 11://HAS BUG 
				int[] addr_11 = new int[2];
				int[] R_t_in4_11 = new int[4];
				R_t_in4_11 = GetComponent<support_func> ().short_to_bit_4x4 (R_t);
				addr_11 [0] = R_t_in4_11 [0];
				addr_11 [1] = R_t_in4_11 [1];
				R_d = DB_access.GetComponent<Data_Base> ().get_register_byid (data [2]);
				int[] data_11 = GetComponent<support_func> ().short_to_bit_4x4 (R_d);
				DB_access.GetComponent<Data_Base> ().set_Memory (addr_11,data_11);//set register
				break;
			case 12://branch_zero
				R_d = DB_access.GetComponent<Data_Base> ().get_register_byid (data [2]);
				if(R_d==0){//success
					P_C = data_addr_ary;
					P_C [0] -= 1;//add one at the end
				}//it is ok that P_C[0]<0
				break;
			case 13://branch positive
				R_d = DB_access.GetComponent<Data_Base> ().get_register_byid (data [2]);
				if(R_d>0){//success
					P_C = data_addr_ary;
					P_C [0] -= 1;//add one at the end
				}//it is ok that P_C[0]<0
				break;
			case 14://jump register, just use the last two bits
				int[] data_14;
				data_14 = GetComponent<support_func> ().short_to_bit_4x4 (R_t);//int[4]
				P_C [0] = data_14 [0];
				P_C [1] = data_14 [1];
				P_C [0] -= 1;
				break;
			case 15://jump and link
				R_d=(short)(P_C[0]+P_C[1]*16);
				DB_access.GetComponent<Data_Base> ().set_register_byid (data [2], R_d);//set register
				P_C = data_addr_ary;
				P_C [0] -= 1;//add one at the end
				break;
			}


			P_C=next_P_C(P_C);
			if(P_C[0]==0&&P_C[1]==0){//fail to add 1, P_C is [0,0]
				Debug.Log("over 256 memory!");
				game_running = false;
				break;
			}
			yield return new WaitForSeconds(1);
		}
		Main_access.GetComponent<Main_controller> ().change_machine_status(0);//set not running


	}
}
