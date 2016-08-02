using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {
    bool played = false;
    public bool stopOther = false;
    public GameObject other;
    // Use this for initialization
    void Start () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!played && other.tag == "Player")
        {
            GetComponent<AudioSource>().PlayDelayed(2.0f);
            played = true;
            if (stopOther)
            {
                other.GetComponent<AudioSource>().Stop();
            }
        }

    }

}
