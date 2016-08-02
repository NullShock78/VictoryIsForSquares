using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class AskForWink : MonoBehaviour {

    public GameObject spriteToDisplay;
    private bool inRange = false;
    void Start ()
    {
        spriteToDisplay.SetActive(false);
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            spriteToDisplay.SetActive(true);
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spriteToDisplay.SetActive(false);
            inRange = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spriteToDisplay.SetActive(true);
            inRange = true;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (inRange && CrossPlatformInputManager.GetButtonDown("Submit"))
        {
            GetComponent<Animator>().Play("Happy");

            Destroy(spriteToDisplay, .73f);
            Destroy(gameObject, .73f);
        }
    }
}
