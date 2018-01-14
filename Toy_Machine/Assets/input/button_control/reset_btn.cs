using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class reset_btn : MonoBehaviour {
	public GameObject main_controller;//access
	void Start () {
		main_controller = GameObject.Find("Main_controller");//get access to main_controller
		GetComponent<Button>().onClick.AddListener(RESET);
	}

	void RESET(){
		if(main_controller.GetComponent<Main_controller>().check_running()==0){//not running
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}
	}
}
