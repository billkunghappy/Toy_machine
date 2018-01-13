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
	public int four_bit_convert(int bit_0,int bit_1,int bit_2,int bit_3){
		int sum = 0;
		sum += bit_0;
		sum += bit_1*power_2(1);
		sum += bit_2*power_2(2);
		sum += bit_3*power_2(3);
		return sum;
	}


}
