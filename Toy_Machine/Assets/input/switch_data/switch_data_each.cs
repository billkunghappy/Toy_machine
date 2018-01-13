using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switch_data_each : MonoBehaviour {
	Image myImageComponent;
	public Sprite closed_switch; //Drag your first sprite here in inspector.
	public Sprite opened_switch; //Drag your second sprite here in inspector.

	public int which_switch=0;
	// Use this for initialization

	void Start () {
		myImageComponent = GetComponent<Image>();//find my image
		GetComponent<Button>().onClick.AddListener(TaskOnClick);
	}
	// Update is called once per frame
	void Update () {

	}
	void TaskOnClick()
	{
		if (myImageComponent.sprite == closed_switch) {
			myImageComponent.sprite = opened_switch;
			this.GetComponentInParent<switch_data_main_control> ().Data_status [which_switch]=1;
			//changed the value in parent directly
		} else {
			myImageComponent.sprite = closed_switch;
			this.GetComponentInParent<switch_data_main_control> ().Data_status [which_switch]=0;
		}

	}
}
