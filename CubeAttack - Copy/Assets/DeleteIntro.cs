using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class DeleteIntro : MonoBehaviour {

	// Use this for initialization
	void Start () {
      
	}

    private void Awake()
    {
        Destroy(gameObject, 39.0f);

    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton("Submit"))
        {
            Destroy(gameObject);
        }
	}
}
