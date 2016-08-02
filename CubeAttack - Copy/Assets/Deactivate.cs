using UnityEngine;
using System.Collections;

public class Deactivate : MonoBehaviour {


    //[SerializeField]
    //GameObject objectToDeactivate;
    [SerializeField]
    string tagToDetect;
    //[SerializeField]
    //string componentToDeactivate;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(tagToDetect))
        {
            other.GetComponent<EnemyAI2>().enabled = false;
           // other.GetComponent<BoxCollider2D>().sharedMaterial.friction = 1.0f;
        }
    }


    // Update is called once per frame
    void Update () {
	        
	}
}
