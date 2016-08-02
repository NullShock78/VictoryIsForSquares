using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update () {
	

	}
}
