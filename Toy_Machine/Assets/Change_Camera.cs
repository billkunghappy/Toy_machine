using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Change_Camera : MonoBehaviour
{
    public Transform now_camera;
    private void Start()
    {
        now_camera = this.GetComponent<Transform>();
        now_camera.position = new Vector3(0,0,-10);
    }

    public void changeCamera()
    {
        now_camera.position = new Vector3(30, 0, -10);
    }
	public void backCamera()
	{
		now_camera.position = new Vector3 (0, 0, -10);
	}

}
