using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public float scrollSpeed = 0.5F;
    public Renderer rend;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }
}
