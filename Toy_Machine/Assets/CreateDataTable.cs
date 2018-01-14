using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateDataTable : MonoBehaviour {
    public GameObject Unit;
    public GameObject DB_access;
    public GameObject[] all_units;

    // Use this for initialization
    void Start () {
        Create();
        all_units = GameObject.FindGameObjectsWithTag("the_unit");
        DB_access = GameObject.Find("database");
    }
    void Create() {
        for (int i = 0; i < 256; i++) {
            GameObject now = GameObject.Instantiate(Unit, this.transform.position, this.transform.rotation) as GameObject;

            now.transform.SetParent(this.transform);
            now.transform.localScale = Vector3.one;

            string one, two;
            string[] tmp = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            one = tmp[i / 16];
            two = tmp[i % 16];

            now.transform.name = "unit" + one + two;
            now.transform.Find("value").GetComponent<Text>().text = "0000";
        }
    }

	// Update is called once per frame
	void Update () {
        int[] addr = { 0, 0 };
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < 16; j++) {

                //Debug.Log( (i*16+j) );


                string[] tmp = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
                addr[1] = i; addr[0] = j;
                int[] now = DB_access.GetComponent<Data_Base>().get_data(addr);

                Text now_unit;
                now_unit = all_units[i * 16 + j].GetComponentInChildren<Text>();
                now_unit.text = tmp[now[3]] + tmp[now[2]] + tmp[now[1]] + tmp[now[0]];

                
            }   
        }
    }
}
