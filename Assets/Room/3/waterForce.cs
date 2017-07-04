using UnityEngine;
using System.Collections;

public class waterForce : MonoBehaviour {
    bool entered=true;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //if (entered) { 
        //    Rigidbody rg = GameObject.Find("daisy 2").GetComponent<Rigidbody>();
        //    GameObject.Find("daisy 2").GetComponent<Rigidbody>().velocity = new Vector3(rg.velocity.x, rg.velocity.y + 0.4f, rg.velocity.z);
        //    Debug.Log("water!!");
        //}
    }
    void OnTriggerEnter(Collider col)
    {
        GameObject.Find("daisy 2").SendMessage("setWater", true);
        //Debug.Log("water");
        Physics.gravity =new Vector3(10f,-15.0f,0);
        GameObject.Find("splash").SendMessage("dodosplash");
        
    }
    void OnTriggerExit(Collider col)
    {
        GameObject.Find("daisy 2").SendMessage("setWater", false);
        Debug.Log("waterout");
        Physics.gravity = new Vector3(0, -70.0f, 0);
        GameObject.Find("splash").SendMessage("dodosplash");
    }
    private void OnTriggerStay(Collider collision)
    {
        GameObject.Find("daisy 2").SendMessage("setWater", true);
        Debug.Log("water");
        Physics.gravity = new Vector3(10f, -15.0f, 0);
        //GameObject.Find("daisy 2").GetComponent<Rigidbody>().velocity=new Vector3(GameObject.Find("daisy 2").GetComponent<Rigidbody>().velocity.x+0.1f, GameObject.Find("daisy 2").GetComponent<Rigidbody>().velocity.y, GameObject.Find("daisy 2").GetComponent<Rigidbody>().velocity.z);
    }
}
