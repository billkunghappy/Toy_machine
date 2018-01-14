﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Data_Base : MonoBehaviour {
	public int[,] all_Memory = new int[256,4];//16*16, 4digit data(16進)
	public short[] all_register = new short[16];//-128~127, register[0] is always 0
	//set public for now
	public int[] get_data(int[] Addr){
		int[] return_data = new int[4];
		for (int i = 0; i < 4; i++) {
			return_data [i] = all_Memory [Addr [1] * 16 + Addr [0], i];
		}
		return return_data;
	}
	public int set_Memory(int[] ADDR,int[] Data){//return 1 if set successfully
		for (int i = 0; i < 2; i++) {
			if (ADDR [i] >= 16 || ADDR [i] < 0) {
				return 0;
			}
		}
		for (int i = 0; i < 4; i++) {
			if (Data [i] >= 16 || Data [i] < 0) {
				return 0;
			}
		}
		if(ADDR[0]==15&&ADDR[1]==15){
			return 0;
		}//	can't touch FF
		//above is error setting memory
		//ADDR[0]是右邊的位元 ADDR == 73, ADDR[0] == 3
		Debug.Log (ADDR [1] * 16 + ADDR [0]);
		for (int i = 0; i < 4; i++) {
			all_Memory [ADDR [1] * 16 + ADDR [0], i] = Data [i];
			Debug.Log (Data[i]);
		}
		return 1;
	}
	public short get_register_byid(int id){
		return all_register [id];
	}
	public void set_register_byid(int id,short data){//return 1 if sccess
		if (id == 0) {
			Debug.Log ("you can't modify REG[0]");
		} else {
			all_register [id] = data;
		}
	}

}
