using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour {

    public GameObject gameOverScreen;
    public GameObject hurtSound;
    public GameObject[] hearts;
    public Transform followPoint;
    public string tagToDetect;
    private int hp;
    public float invFrames = 0.5f;
    private float iFrames = 0.0f;
    private bool invincible = false;
	// Use this for initialization
	void Start () {
        hp = hearts.Length-1;
	}


    void OnTriggerEnter2D(Collider2D other)
    {


        if (!invincible && other.tag == tagToDetect && hp >= 0)
        {
            hearts[hp].SetActive(false);
            hp--;
            hurtSound.GetComponent<AudioSource>().Play();
            invincible = true;
            if (hp < 0)
            {
                GetComponent<Animator>().Play("Death");
                SendMessage("Kill");
                followPoint.SetParent(null);
                Instantiate(gameOverScreen, new Vector3(transform.position.x,transform.position.y - .5f, transform.position.z), transform.rotation);
                Destroy(gameObject, 4.0f);
            }
            
        }
    }

    // Update is called once per frame
    void Update () {
        if (invincible)
        {
            iFrames += Time.deltaTime;
            if (iFrames >= invFrames)
            {
                iFrames = 0.0f;
                invincible = false;
            }
        }
	}
}
