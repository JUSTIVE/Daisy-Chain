using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class underbed : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col) {
        GameObject.Find("Text").GetComponent<Text>().text = "\n\n아늑한 침대 밑이다";
    }
    private void OnTriggerExit(Collider other)
    {
        GameObject.Find("Text").GetComponent<Text>().text = "\n\n넓은 방이다";
    }
}
