using UnityEngine;
using System.Collections;

public class waterFlow : MonoBehaviour {

    public float scrollSpeed = 5.0F;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        
    }
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(0, -offset);
    }
}
