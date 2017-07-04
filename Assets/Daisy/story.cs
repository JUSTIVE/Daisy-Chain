using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class story : MonoBehaviour {
    private int roomNumber;
    private string[] Room1Script = { "\n\n데이지는 잠에서 깼다", "\n\n여긴 어디지?" };
    private string[] Room1_2Script = { };
    private int scriptIndex;
    private bool ablePass=true;
    private string[] targetScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (Input.anyKey)
        {
            if (ablePass)
            {
                ablePass = false;
                Invoke("ScriptHolder",1f);
                GameObject.Find("TextScript").GetComponent<Text>().text = targetScript[scriptIndex];
                scriptIndex++;
            }
        }
	}
    
    void ScriptHolder()
    {

    }
    void setRoomNumber(int room)
    {
        scriptIndex = 0;
        roomNumber = room;
        switch (roomNumber)
        {

        }
    }
}
