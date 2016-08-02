using UnityEngine;
using System.Collections;

public class Activate : MonoBehaviour {

    [SerializeField]
    float posToCheck;
    [SerializeField]
    GameObject[] gameObjects;
    [SerializeField]
    private bool active = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 if( !active && transform.position.y >= posToCheck)
        {
            active = true;
            foreach(GameObject g in gameObjects)
            {
                g.SetActive(true);
                g.GetComponent<EnemyAI2>().enabled = true;
                //g.SendMessage("setActive", true);
            }
        }

	}
}
