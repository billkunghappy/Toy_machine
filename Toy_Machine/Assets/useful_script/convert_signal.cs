using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convert_signal : MonoBehaviour {
	public int[] light_convert16(int main_signal){
		int[] signal_send;
		switch (main_signal) {
		case 0:
			signal_send = new int[4]{ 0, 0, 0, 0 };
			return signal_send;
		case 1:
			signal_send = new int[4]{ 0, 0, 0, 1 };
			return signal_send;
		case 2:
			signal_send = new int[4]{ 0, 0, 1, 0 };
			return signal_send;
		case 3:
			signal_send = new int[4]{ 0, 0, 1, 1 };
			return signal_send;
		case 4:
			signal_send = new int[4]{ 0, 1, 0, 0 };
			return signal_send;
		case 5:
			signal_send = new int[4]{ 0, 1, 0, 1 };
			return signal_send;
		case 6:
			signal_send = new int[4]{ 0, 1, 1, 0 };
			return signal_send;
		case 7:
			signal_send = new int[4]{ 0, 1, 1, 1 };
			return signal_send;
		case 8:
			signal_send = new int[4]{ 1, 0, 0, 0 };
			return signal_send;
		case 9:
			signal_send = new int[4]{ 1, 0, 0, 1 };
			return signal_send;
		case 10:
			signal_send = new int[4]{ 1, 0, 1, 0 };
			return signal_send;
		case 11:
			signal_send = new int[4]{ 1, 0, 1, 1 };
			return signal_send;
		case 12:
			signal_send = new int[4]{ 1, 1, 0, 0 };
			return signal_send;
		case 13:
			signal_send = new int[4]{ 1, 1, 0, 1 };
			return signal_send;
		case 14:
			signal_send = new int[4]{ 1, 1, 1, 0 };
			return signal_send;
		case 15:
			signal_send = new int[4]{ 1, 1, 1, 1 };
			return signal_send;
		}
		signal_send = new int[4]{ 0, 0, 0, 0 };
		print ("error in convert signal!");
		return signal_send;
	}

}
