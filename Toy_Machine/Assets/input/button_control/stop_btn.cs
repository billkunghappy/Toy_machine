using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stop_btn : MonoBehaviour {

	void Start () {
		GetComponent<Button>().onClick.AddListener(STOP);
	}

	void STOP(){
		GameObject.Find ("Execute_program").GetComponent<execute_program> ().game_running = false;
		Debug.Log ("press stop");
	}
}
