using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class Restart : MonoBehaviour {
    private bool alive = false;

    [SerializeField]
    string scene = "Menu";

    // Use this for initialization
    void Start () {
        alive = false;
	}

    void Awake()
    {
        alive = true;
    }
	
	// Update is called once per frame
	void Update () {

        //if (alive)
       // {
            if (CrossPlatformInputManager.GetButton("Cancel"))
            {
                SceneManager.LoadScene(scene);
            }
       // }
	}
}
