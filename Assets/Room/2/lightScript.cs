using UnityEngine;
using System.Collections;

public class lightScript : MonoBehaviour {
    private int targetRangeIndex;
    public Light targetLight;
    private int index;
    private float[] rangeValue = {0f,2f,6f,12f,20f};
	// Use this for initialization
	void Start () {
        targetLight.range = 0;
        index = 0;
	}
	
	// Update is called once per frame
	void Update () {
        targetLight.range = rangeValue[index];
        if (targetRangeIndex>index)
        {
            index++;
        }
        if (targetRangeIndex < index)
        {
            index--;
        }
    }
    void setTargetRangeIndex(int f)
    {
        targetRangeIndex = f;
    }
}
