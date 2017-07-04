using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Room2Clear : MonoBehaviour {

    private bool[] clear;
	// Use this for initialization
	void Start () {
        clear = new bool[3];
        for(int i = 0; i < 3; i++)
        {
            clear[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if ((clear[0]==true)&&(clear[1]==true)&&(clear[2]==true))
        {
            Destroy(GameObject.Find("room2Exitwall"));
            GameObject.Find("arrowRenderer").GetComponent<MeshRenderer>().enabled = true; ;
            GameObject.Find("TextScript").GetComponent<Text>().text = "\n\n화살표 방향으로 가보자";
        }
        //Debug.Log(clear[0].ToString()+ clear[1].ToString()+clear[2].ToString());
	}
    void setClear(int n)
    {
        clear[n] = !clear[n];
    }
}
