using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textShooter : MonoBehaviour {
    public string shootingString;
    // Use this for initialization
	void Start () {
	    
	}
	void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "daisy 2")
        {
            if (name == "bookShelf")
            {
                GameObject.Find("TextScript").GetComponent<Text>().text = "\n\n책이 정리되어 있다";
            }

        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "daisy 2")
        {
            if (name == "bookShelf")
            {
                GameObject.Find("TextScript").GetComponent<Text>().text = "\n\n넓은 방이다";
            }
        }
    }
}
