using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour {
	public int[] P_C;
	//public for debug

	// Use this for initialization
	public int set_PC(int[] Addr){//return 1 if success
		if(Addr[0]>=16||Addr[1]>=16||Addr[0]<0||Addr[1]<0){
			return 0;
		}
		P_C[0]=Addr[0];
		P_C[1]=Addr[1];

		//if return 1, Main_controller will update pc_lights
		return 1;
	}
	void Start () {
		P_C = new int[]{ 0, 1 };
	}
	// Update is called once per frame
	void Update () {
		
	}
}
