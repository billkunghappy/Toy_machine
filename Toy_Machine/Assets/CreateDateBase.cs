using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CreateDateBase : MonoBehaviour {
    public GameObject DB_access;
	public GameObject[] all_rows;
	public GameObject Row;

    // Use this for initialization
    private void Start() {
        Create();
		all_rows = GameObject.FindGameObjectsWithTag ("the_row");
		DB_access = GameObject.Find("database");
    }

    
    void Create () {
        for (int i = 0; i < 256; i++) {
			GameObject now = GameObject.Instantiate(Row, this.transform.position, this.transform.rotation) as GameObject;
            
			now.transform.SetParent(this.transform);
            now.transform.localScale = Vector3.one;

            string one,two;
            string[] tmp = { "0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F" };
            one = tmp[i / 16];
            two = tmp[i % 16];

            now.transform.name = "row" + one+two;
            now.transform.Find("position").GetComponent<Text>().text = one+two;
            now.transform.Find("value").GetComponent<Text>().text = "0";
        }
    }
	// Update is called once per frame
	void Update () {

        int[] addr = { 0, 0 };

        for (int i = 0;i < 16;i++){
			for (int j = 0; j < 16; j++) {
                string[] tmp = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
                addr[1] = i;addr[0] = j;
                int[] now = DB_access.GetComponent < Data_Base > ().get_data( addr );

				Text[] now_row;
				now_row = all_rows [i * 16 + j + 1].GetComponentsInChildren<Text> ();
				now_row[1].text = tmp[now[3]] + tmp[now[2]] + tmp[now[1]] + tmp[now[0]];

            }
        }
        
	}
    



}
