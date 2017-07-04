using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class setScript : MonoBehaviour {
    public string Enter;
    public string Exit;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("TextScript").GetComponent<Text>().text = "\n\n" + Enter;
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject.Find("TextScript").GetComponent<Text>().text = "\n\n" + Exit;
    }

}
