using UnityEngine;
using System.Collections;

public class TreeSpawn : MonoBehaviour {

    [SerializeField]
    private GameObject treePrefab;
    [SerializeField]
    private float minspawnTime;
    [SerializeField]
    private float maxspawnTime;

    private float chosenspawnTime;
    [SerializeField]
    private float despawnTime;

    private float currentTime = 0.0f;

    // Use this for initialization
    void Start () {
        chosenspawnTime = maxspawnTime;

    }


	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        
        if(currentTime >= chosenspawnTime)
        {
            currentTime = 0.0f;
            chosenspawnTime = Random.Range(minspawnTime, maxspawnTime);
            GameObject temp = Instantiate(treePrefab, transform.position, transform.rotation) as GameObject;
            Destroy(temp, despawnTime);
        }
	}
}
