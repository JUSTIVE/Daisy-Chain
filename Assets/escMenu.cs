using UnityEngine;
using System.Collections;

public class escMenu : MonoBehaviour {
    bool enable;
    bool noRepeat;
    bool state;
	// Use this for initialization
	void Start () {
        enable = false;
        state = false;
        noRepeat = true;
	}
	void escMenuEnable()
    {
        enable = true;
    }
	// Update is called once per frame
	void Update () {
        if (enable) { 
            if (noRepeat)
            {
                noRepeat = false;
                if (Input.GetKey(KeyCode.Escape))
                {
                    if (state)//활성화된 상태
                    {
                        
                        GameObject.Find("exitButton").transform.position = Vector3.Lerp(GameObject.Find("exitButton").transform.position,new Vector3(1000f, 1000f, 1000f),Time.deltaTime*5);
                        //Time.timeScale = 1;
                        state = false;
                    }
                    else//비활성화된 상태
                    {
                        state = true;
                        
                        //Time.timeScale = 0;

                    }
                }
                
                Invoke("repeatInvoker",0.5f);

            }
            if (state)
            {
                GameObject.Find("exitButton").SendMessage("exitButtonShowOnCamera");
            }
        }
    }
    void repeatInvoker()
    {
        noRepeat = true;

    }
}
