using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed_scroll : MonoBehaviour {
	
	public void chang_speed(){
		Slider bar;
		bar= this.GetComponent<Slider> ();
		GameObject.Find ("Execute_program").GetComponent<execute_program> ().change_waiting_second (bar.value);

	}
}
