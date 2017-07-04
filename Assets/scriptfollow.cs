using UnityEngine;
using System.Collections;

public class scriptfollow : MonoBehaviour {

    public GameObject target;
	// Use this for initialization
	void Start () {
        //transform.rotation = target.transform.rotation;
        transform.position = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec= target.transform.position;
        vec.y += 5;
        transform.position = vec;
    }
}
