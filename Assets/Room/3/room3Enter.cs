using UnityEngine;
using System.Collections;

public class room3Enter : MonoBehaviour {
    private bool enabler;
    private bool collide;
	// Use this for initialization
	void Start () {
        enabler = true;
        collide = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnCollisionEnter(Collision collision)
    {
        
        if(enabler==true)
        {
            enabler = false;
            GameObject.Find("Scene1Eye").SendMessage("setMiddleGrey", 0.5f);
            GameObject.Find("Scene1Eye").SendMessage("setZoom", 40f);
            // GameObject.Find("Scene1Eye").SendMessage("setClippingNear", -60);
            GameObject.Find("room3cover").GetComponent<Collider>().enabled = true;
        }
        collide = true;
        
    }
    private void OnCollisionStay(Collision collision)
    {
        
        
    }
}
