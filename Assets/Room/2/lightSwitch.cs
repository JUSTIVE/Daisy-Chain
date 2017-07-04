using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lightSwitch : MonoBehaviour {
    public int[] index;
    public Light myLight;
    private Light[] lights;
    private bool pulse;
    private bool pulseActivator;

    public AudioClip jumpSound;
    private AudioSource source;
    // Use this for initialization
    void Start () {
        lights = new Light[5];
        for(int i=0;i<5;i++) {
            GetComponent<Light>();
            lights[i] = GameObject.Find("Treelights").GetComponentsInChildren<Light>()[index[i]];
        }
        pulseActivator = true;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {
	    
	}
    void LightUp() {
        myLight.SendMessage("setTargetRangeIndex",4);
        Invoke("LightDown", 0.5f);
    }
    void LightDown()
    {
        myLight.SendMessage("setTargetRangeIndex", 0f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "daisy 2")
            if (pulseActivator)
            {
                pulse = true;
                pulseActivator = false;
                GameObject.Find("TextScript").GetComponent<Text>().text = "\n\n밟으면 빛이 나는 발판이다ㅣ";
                source.PlayOneShot(jumpSound, 1f);

            }
        if (pulse)
        {
            GameObject.Find("Room2").SendMessage("setClear",index[0]);
            pulse = false;
            LightUp();
            for(int i = 0; i < 5; i++)
            {
                if (lights[i].enabled)
                {
                    lights[i].enabled = false;
                }
                else
                {
                    lights[i].enabled = true;
                }
            }
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "daisy 2")
            pulseActivator = true;
    }
    bool getPulse()
    {
        return pulse;
    }
}
