using UnityEngine;
using System.Collections;

public class EscapedRoom : MonoBehaviour {

    public new GameObject camera;
    
    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "land1 (6)"|| col.gameObject.name == "land1 (2)")
        {
            camera.SendMessage("setZoom",40f);
        }
        if (col.gameObject.name == "Room")
        {
            camera.SendMessage("setZoom", 20f);
        }
    }
}
