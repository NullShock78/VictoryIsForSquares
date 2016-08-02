using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class OptionLoader : MonoBehaviour {


    public GameObject spriteToDisplay;
    public GameObject spriteToDisplay2;
    [SerializeField]
    private string SceneToLoad;
    private bool inRange = false;
    private bool winkedAt = false;
    private bool hitExit = false;
    [SerializeField]
    private bool exitMenuOverride = false;
    void Start()
    {
        spriteToDisplay.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !winkedAt)
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
            spriteToDisplay2.SetActive(false);
            winkedAt = false;

            inRange = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //spriteToDisplay.SetActive(true);
            inRange = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (exitMenuOverride)
        {
            if (!hitExit && CrossPlatformInputManager.GetButton("ExitGame"))
            {
                hitExit = true;
                //spriteToDisplay.SetActive(false);
                spriteToDisplay2.SetActive(true);


            }

            if (hitExit && CrossPlatformInputManager.GetButton("Submit"))
            {
                hitExit = false;
                //spriteToDisplay.SetActive(false);
                spriteToDisplay2.SetActive(false);
            }
            else if (hitExit && CrossPlatformInputManager.GetButton("Jump"))
            {
                Application.Quit();
            }


        }
        else
        {


            if (!winkedAt && inRange && CrossPlatformInputManager.GetButton("Submit"))
            {
                winkedAt = true;
                spriteToDisplay.SetActive(false);
                spriteToDisplay2.SetActive(true);
                //GetComponent<Animator>().Play("Happy");
                //GetComponent<AudioSource>().PlayDelayed(0.4f);
                //Destroy(spriteToDisplay, .73f);
                // Destroy(gameObject, .73f);
            }

            if (winkedAt && inRange && CrossPlatformInputManager.GetButton("Cancel"))
            {
                if (SceneToLoad.Equals("Quit"))
                {

                    Application.Quit();

                }
                else {
                    SceneManager.LoadScene(SceneToLoad);
                }
            }
        }
    }
}
