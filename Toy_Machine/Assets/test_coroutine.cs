using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_coroutine : MonoBehaviour {
	IEnumerator MyCoroutine()
	{
		while ( !Input.GetKeyDown(KeyCode.DownArrow) )
			yield return null;
		print("press down");
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(MyCoroutine());
		print ("go to next step");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
