using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class CirclonAskForMercy : MonoBehaviour {
    public GameObject spriteToDisplay;
    public GameObject gameWinScreen;
    public GameObject player;
    public Transform playerCam;
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
        if (!dead && inRange && CrossPlatformInputManager.GetButton("Submit"))
        {
            playerCam.SetParent(null);
           
            player.SendMessage("playSound");

            SceneManager.LoadScene("Credits");
            GetComponent<Animator>().Play("Happy");
            //Instantiate(gameWinScreen, transform.position, transform.rotation);
            //player.GetComponent<Animator>().Play("Wink2");
            //Destroy(player, .3f);
            player.GetComponent<Animator>().Play("WinkWin");
            player.SendMessage("Flip");
            player.SendMessage("Kill");
            Destroy(spriteToDisplay, .73f);
            Destroy(gameObject, .73f);
            dead = true;
        }
    }
}
