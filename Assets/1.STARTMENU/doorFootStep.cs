using UnityEngine;
using System.Collections;

public class doorFootStep : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {      
        GameObject.Find("Room2").SendMessage("RoomMoveInit");
    }
    void OnCollisionExit(Collision col)
    {

    }
}
