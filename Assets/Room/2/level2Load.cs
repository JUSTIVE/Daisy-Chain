using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class level2Load : MonoBehaviour {
    private bool move;
    // Use this for initialization
    void Start () {
        move = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(133.3f, 0f, 97.8f), Time.deltaTime * 3);
            GameObject.Find("TextScript").GetComponent<Text>().text="\n\n데이지 : \"저건 뭐지?\"";
            Invoke("stop",2);
        }
    }
    private void stop()
    {
        move = false;
    }
    public void RoomMoveInit()
    {
        move = true;
    }
}
