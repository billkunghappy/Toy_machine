using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_btn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void Load_be_pressed() {
        GameObject now = GameObject.Find("Main_controller");
        now.GetComponent<Main_controller>().Load_input(1);
    }
}
