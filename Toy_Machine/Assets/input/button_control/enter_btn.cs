using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enter_btn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(ENTER);
	}
	
	void ENTER(){
		GameObject.Find ("Execute_program").GetComponent<execute_program>().isEnter = false;
		Debug.Log ("press enter");
	}

}
