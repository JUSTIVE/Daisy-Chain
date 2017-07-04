using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour {
    public Light pointLight;
    public Camera sceneEye;
    private bool isHover;
    private bool isFocused;
	// Use this for initialization
	void Start () {
        isHover = false;
	}
    void FocusToggle()
    {
        if (isFocused)
        {
            isFocused = false;
            return;
        }
        isFocused = true;
    }
    void FocusToggle(bool value)
    {
        isFocused = value;
    }
    // Update is called once per frame
    void Update () {
        if (isHover && Input.GetMouseButtonDown(0))
        {
            //GameObject.Find("chatBox").GetComponent<MeshRenderer>().enabled = true;
            sceneEye.SendMessage("gameStarted");
            
        }
        if (isHover)
        {
            pointLight.intensity = (pointLight.intensity+50f*Time.deltaTime)<8f? (pointLight.intensity + 50f* Time.deltaTime):8f;
        }
        else
        {
            pointLight.intensity = (pointLight.intensity - 1f * Time.deltaTime) > 8f ? (pointLight.intensity - 1f * Time.deltaTime) : 0f;
        }
    }
    void OnMouseOver()
    {
        isHover = true;
    }
    void OnMouseExit()
    {
        isHover = false;
    }
}
