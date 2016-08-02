using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class AskForWinkSound : MonoBehaviour {


    public GameObject spriteToDisplay;
    private bool inRange = false;
    private bool winkedAt = false;
    void Start()
    {
        spriteToDisplay.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
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
    void Update()
    {
        if (!winkedAt && inRange && CrossPlatformInputManager.GetButton("Submit"))
        {
            winkedAt = true;
            GetComponent<Animator>().Play("Happy");
            GetComponent<AudioSource>().PlayDelayed(0.4f);
            Destroy(spriteToDisplay, .73f);
            Destroy(gameObject, .73f);
        }
    }
}
