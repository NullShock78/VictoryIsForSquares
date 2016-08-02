using UnityEngine;
using System.Collections;

public class CloudSway : MonoBehaviour {

    public float swaySpeed = 1.0f;
    private float sway; //= 1.0f;
    public float flipTime = 1.0f;
    private float currentTime = 0.0f;

    // Use this for initialization
    void Start () {
        sway = swaySpeed/1000.0f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(sway*50.0f * Time.deltaTime,0,0);
        currentTime += Time.deltaTime;

        if(currentTime >= flipTime)
        {
            currentTime = 0.0f;
            sway = -sway;
        }
	}
}
