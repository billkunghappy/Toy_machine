using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class support_func : MonoBehaviour {
	public int power_2(int a){
		int sum = 1;
		for (int i = 0; i < a; i++) {
			sum *= 2;
		}
		return sum;
	}
	public int power_16(int a){
		int sum = 1;
		for (int i = 0; i < a; i++) {
			sum *= 16;
		}
		return sum;
	}

	public int four_bit_convert(int bit_0,int bit_1,int bit_2,int bit_3){
		int sum = 0;
		sum += bit_0;
		sum += bit_1*power_2(1);
		sum += bit_2*power_2(2);
		sum += bit_3*power_2(3);
		return sum;
	}
	public short bit_4x4_to_short(int[] data){
		ushort sum = 0;
		for (int i = 0; i < 4; i++) {
			sum += (ushort)(data [i] * power_16 (i));
			print ("sum is " + sum);
		}
		Debug.Log(sum+"=.="+(short)sum);
		return (short)sum;
	}
	public int[] short_to_bit_4x4(short data){
		int[] return_data = new int[4]{0,0,0,0};

		ushort data_cache = 0;
		data_cache = (ushort)data;
		Debug.Log (data_cache + " == " + data);
		for (int i = 3; i >=0; i--) {
			return_data[i] = data_cache / power_16 (i);
			print (i + " is " + return_data [i]);
			data_cache -= (ushort)(return_data [i] * power_16 (i));
		}
			
		return return_data;
	}



}
