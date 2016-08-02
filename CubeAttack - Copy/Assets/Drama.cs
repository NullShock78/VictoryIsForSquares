using UnityEngine;
using System.Collections;

public class Drama : MonoBehaviour {

    bool played = false;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!played && other.tag == "Player")
        {
            GetComponent<AudioSource>().PlayDelayed(.03f);
            played = true;
        }
    }


   
    // Update is called once per frame
    void Update () {
	
	}
}
