using UnityEngine;
using System.Collections;

public class RoomMove : MonoBehaviour {

    bool isAway;
	// Use this for initialization
	void Start () {
        isAway = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isAway)
        {
            transform.position = Vector3.Lerp(this.transform.position,new Vector3(33,78,131),Time.deltaTime);
            Invoke("destroy", 8);
        }
        
	}
    void destroy()
    {

    }
    public void setAway(bool value)
    {
        isAway = value;
    }
}
