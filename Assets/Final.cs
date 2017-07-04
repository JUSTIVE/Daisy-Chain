using UnityEngine;
using System.Collections;

public class Final : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Room (1)").transform.position = new Vector3(20f, -426.8f, -0f);
    }
}
