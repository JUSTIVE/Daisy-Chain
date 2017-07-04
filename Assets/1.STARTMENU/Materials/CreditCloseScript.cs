using UnityEngine;
using System.Collections;

public class CreditCloseScript : MonoBehaviour {
    private bool isHover;
    public GameObject cameras;
    public Light pointLight;
    private bool isFocused;
    // Use this for initialization
    void Start() {
        isFocused = false;
    }

    // Update is called once per frame
    void Update() {
        if (isHover && Input.GetMouseButtonDown(0))
        {
            cameras.SendMessage("creditEnded");
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
    void OnMouseOver()
    {
        isHover = true;
        
    }
    void OnMouseExit()
    {
        isHover = false;
    }
}
