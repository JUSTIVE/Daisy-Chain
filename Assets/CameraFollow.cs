using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class CameraFollow : MonoBehaviour {


    public GameObject player;//Public variable to store a reference to the player game object
    
    public Camera camera;//Main Camera Object 
    private Vector3 offset;//Private variable to store the offset distance between the player and camera
    private int state;//variable for game status

    private float targetzoom;//camera zoom variable

    private string[] scripts=new string[10];//variable for script
    public Text textScript;//variable for chatBox
    float targetMiddleGrey;//setting
    
    
    bool isEscapedRoom = false;//did Daisy Escaped room1?
    bool animationStart = false;//isAnimationStart?
    int MenuFocus;
    bool chatSwapAble=true;//variable fot switching chatbox time lag
    private int script_state;//current state for TextScript
    enum SCRIPT_STATE {DOWN,UP};//state for TextScript
    enum CAMERA_STATE {INTRO,MENU,INGAME,CREDIT}; //state for camera 


    // Use this for initialization
    void Start () {
        state = (int)CAMERA_STATE.INTRO;
        transform.rotation = Quaternion.Euler(new Vector3(90, 45, 90));
        //transform.position = new Vector3(0.408f, 0.261f, -0.408f);
        camera.orthographicSize = 5f;
        targetzoom = 5f;
        camera.transform.position = new Vector3(109.0979f, 87.57f, 128.1597f);
        targetMiddleGrey = 0.4f;
        Invoke("splashMovie",2);
        MenuFocus = 0;
        script_state = (int)SCRIPT_STATE.DOWN;
        
    }

	void splashMovie()//for first animation
    {
        animationStart = true;
    }
    void gameStarted()//start following character
    {
        Invoke("follow",0);
    }
    //setCameraFollow and call init
    void follow()
    {
        Invoke("setInit", 3);
        targetMiddleGrey = 0f;
    }

    public void setMiddleGrey(float value)//set adaptiveReinhard middlegrey
    {
        targetMiddleGrey = value;
    }
    void setInit()//reset camera for first stage
    {
        state = (int)CAMERA_STATE.INGAME;
        transform.position = new Vector3(119.7089f, 134.1065f, 110.7479f);
        transform.rotation = Quaternion.Euler(new Vector3(45, -45, 0));
        offset = transform.position - player.transform.position;
        targetzoom = 20f;
        targetMiddleGrey = 0.3f;
        SendMessage("escMenuEnable");
        player.SendMessage("setRun",true);
        Destroy(GameObject.Find("Startbutton"));
        Destroy(GameObject.Find("CreditButton"));
        Destroy(GameObject.Find("MainMenu"));
        
        GameObject.Find("exitButton").transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        GameObject.Find("exitButton").transform.position = new Vector3(1000f, 1000f, 1000f);
        Vector3 target = transform.position;
        GameObject.Find("chatBox").transform.position = target;
    }
     
    //대사 관련된 부분
    void chatScriptAbleToggle()
    {
        chatSwapAble = true;
    }
    void chatScriptUp()
    {
        script_state = (int)SCRIPT_STATE.UP;
    }
    void chatScript(string text)
    {
        GameObject.Find("chatBox").transform.position = new Vector3(camera.transform.position.x-1,camera.transform.position.y,camera.transform.position.z-1);
        textScript.text = text;
    }
    void chatScriptDown()
    {
        script_state = (int)SCRIPT_STATE.DOWN;
    }
    ///////////////////
    //orthographic 카메라의 zoom을 수정하는 변수
    void setZoom(float target)
    {
        if(state ==(int)CAMERA_STATE.INGAME)
            targetzoom = target;
    }
    //is Credit animation started?
    void creditStarted()
    {
        state = (int)CAMERA_STATE.CREDIT;
        targetMiddleGrey = 0.4f;
    }
    //is Player Escaped Credit Menu?
    void creditEnded()
    {
        state = (int)CAMERA_STATE.INTRO;
    }
	// Update is called once per frame
	void Update () {
        switch (state)//switch phrase for each game state
        {
        case (int)CAMERA_STATE.INTRO:
            if (animationStart) { 
                transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(45,-45,0),Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position,new Vector3(109.0979f, 82.57f, 128.1597f),Time.deltaTime);
                targetzoom = Mathf.Lerp(targetzoom, 5, Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow)| Input.GetKey(KeyCode.UpArrow))
            {
                MenuFocus = (MenuFocus + 1) %2;
                if (MenuFocus==0)
                {
                    GameObject.Find("Startbutton").SendMessage("FocusToggle",true);
                    GameObject.Find("CreditButton").SendMessage("FocusToggle", false);
                }
                else
                {
                    GameObject.Find("Startbutton").SendMessage("FocusToggle", false);
                    GameObject.Find("CreditButton").SendMessage("FocusToggle", true);
                }
            }
            if (Input.GetKey(KeyCode.Return))
            {}
            break;
        case (int)CAMERA_STATE.CREDIT:
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 270, 0), Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, new Vector3(103.22f, 88.89999f, 107.19f), Time.deltaTime);
            targetzoom = Mathf.Lerp(targetzoom,5,Time.deltaTime);
            break;
        case (int)CAMERA_STATE.MENU:
            
            break;
        case (int)CAMERA_STATE.INGAME:
            if (Input.GetKey(KeyCode.F))
            {
                if (chatSwapAble) {
                    chatSwapAble = false;
                    if (script_state == (int)SCRIPT_STATE.DOWN)
                        script_state = (int)SCRIPT_STATE.UP;
                    else
                        script_state = (int)SCRIPT_STATE.DOWN;
                    Invoke("chatScriptAbleToggle", 1);
                }
            }
            script_state = (int)SCRIPT_STATE.UP;
            transform.position = player.transform.position + offset;
            break;
        }

        if (script_state == (int)SCRIPT_STATE.DOWN)
        {
            Vector3 target = transform.position;
            target.y -= 120;
            GameObject.Find("chatBox").transform.position = Vector3.Lerp(GameObject.Find("chatBox").transform.position, target, Time.deltaTime*2);
            
        }
        else
        {
            Vector3 target = camera.transform.position;
            target.y -= 20;
            target.z -= 10;
            target.x += 10;
            GameObject.Find("chatBox").transform.position = Vector3.Lerp(GameObject.Find("chatBox").transform.position, target, Time.deltaTime*2);
        }
        SendMessage("updateMiddleGrey",targetMiddleGrey);
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetzoom, Time.deltaTime);
        if (state == (int)CAMERA_STATE.INGAME) { 
            
        }
    }
    //setting clippingnear Value for orthographic Camera
    public void setClippingNear(float value)
    {
        this.camera.nearClipPlane = value;
    }
}
