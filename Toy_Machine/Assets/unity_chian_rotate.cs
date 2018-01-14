using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unity_chian_rotate : MonoBehaviour {
	Transform get_transform;
	void Start () {
		get_transform = this.GetComponent<Transform> ();
	}
	// Update is called once per frame
	int flag=0;
	Vector3 temp;
	void Update () {
		double angle=get_transform.transform.eulerAngles.x+90;
		print (angle);
//		get_transform.Rotate(Vector3.up * (Time.deltaTime)*20);
		get_transform.Rotate(Vector3.up * (Time.deltaTime)*((int)angle*2+1));
		if (flag==0 && get_transform.rotation.y < 90) {
			temp = get_transform.localScale;
			temp = new Vector3 (-temp.x, temp.y, temp.z);
			get_transform.localScale = temp;
			flag = 1;
		}
		if (flag==1 && get_transform.rotation.y > 180) {
			temp = get_transform.localScale;
			temp = new Vector3 (-temp.x, temp.y, temp.z);
			get_transform.localScale = temp;
			flag = 0;
		}
		Debug.Log (get_transform.rotation.x);
	}
}
