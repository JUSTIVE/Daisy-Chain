using UnityEngine;
using System.Collections;

public class doSplash : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void dodosplash()
    {
        transform.position = GameObject.Find("daisy 2").transform.position;
        gameObject.GetComponent<ParticleSystem>().Play();
    }
}
