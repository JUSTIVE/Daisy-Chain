using UnityEngine;
using System.Collections;

public class exitMenuScript : MonoBehaviour {
    public Light pointLight;
    public Camera sceneEye;
    private bool isHover;
    
    // Use this for initialization
    void Start () {
        isHover = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isHover && Input.GetMouseButtonDown(0))
        {
            sceneEye.SendMessage("setMiddleGrey", 0f);
            Application.Quit();
            
        }
        if (isHover)
        {
            pointLight.intensity = (pointLight.intensity + 50f * Time.deltaTime) < 8f ? (pointLight.intensity + 50f * Time.deltaTime) : 8f;
        }
        else
        {
            pointLight.intensity = (pointLight.intensity - 1f * Time.deltaTime) > 8f ? (pointLight.intensity - 1f * Time.deltaTime) : 0f;
        }
    }
    void exitButtonShowOnCamera()
    {
        Vector3 target = sceneEye.transform.position;
        target.y -= 10;
        target.x -= 5;
        target.z -= 5;
        transform.position = Vector3.Lerp(transform.position,target,Time.deltaTime*5);
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
