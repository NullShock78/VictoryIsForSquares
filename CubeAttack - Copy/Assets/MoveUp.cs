using UnityEngine;
using System.Collections;

public class MoveUp : MonoBehaviour {

    [SerializeField]
    float moveTimeMax = 1000;
    float moveTime = 0.0f;
    [SerializeField] float moveSpeed = 1.0f;
	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        if (!(moveTime >= moveTimeMax)) { 
        transform.Translate(0.0f, moveSpeed * Time.deltaTime, 0.0f);
        moveTime += Time.deltaTime;
        }
	}
}
