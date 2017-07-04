using UnityEngine;
using System.Collections;

public class level2enter : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    void OnCollisionEnter(Collision col)
    {
        GameObject.Find("Scene1Eye").SendMessage("setMiddleGrey",0.4f);
        GameObject.Find("Scene1Eye").SendMessage("setZoom",30f);
        GameObject.Find("Scene1Eye").SendMessage("setClippingNear",-40);
        GameObject.Find("Room (1)").SendMessage("setAway",true);
        
    }
}
