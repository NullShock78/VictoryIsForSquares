using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {


    [SerializeField]
    private float moveSpeed;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f));
	}
}
