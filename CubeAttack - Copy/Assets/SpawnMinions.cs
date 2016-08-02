using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class SpawnMinions : MonoBehaviour {
    public GameObject spriteToDisplay;
    private bool inRange = false;
    private bool dead = false;
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
        if (!dead && inRange && CrossPlatformInputManager.GetButton("Submit"))
        {
            Destroy(spriteToDisplay, .73f);
            Destroy(gameObject, .73f);
            dead = true;
        }
    }
}
