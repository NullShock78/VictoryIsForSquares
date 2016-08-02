using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class EnemyAI : MonoBehaviour {


    public string tagToDetect = "Player";
    public float x_moveSpeed = 9f;
    public GameObject blush;
    private bool aggroed = false;
    //private bool searching = false; //======================================
    private float timeOut = 0.0f;
    private const float MAX_WAIT = 3000.0f;
    private float x_pos = 0;
    //private float updateTime = 0.0f;
    private const float MAX_UPDATE_TIME = 200.0f;
    private Vector3 movement;

    // Use this for initialization
    void Start () {
        movement = new Vector3(-x_moveSpeed, 0,0);
    }

    void Chase(float dt)
    {
        
        transform.Translate((movement.x * dt )/10.0f, 0, 0) ;

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == tagToDetect)
        //{
        //    aggroed = true;
        //}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == tagToDetect)
        {
            //searching = true;
            aggroed = false;
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == tagToDetect)
        {
            x_pos = other.transform.position.x;
            aggroed = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        //if (searching)
        //{
        //    if (timeOut >= MAX_WAIT)
        //    {
        //        timeOut = 0.0f;
        //        //searching = false;
        //        //aggroed = false;
        //    }
        //    else
        //    {
        //        timeOut += Time.deltaTime;
        //    }
        //} else
        if (aggroed)
        {

            float dist = Mathf.Abs(x_pos - transform.position.x);

            if(dist <= .2f)
            {

            }else if (x_pos < transform.position.x)
            {
                movement.x = -x_moveSpeed;
            }
            else
            {
                movement.x = x_moveSpeed;
            }

            if (CrossPlatformInputManager.GetButton("Submit"))
            {
                if (!blush.activeSelf)
                {
                    blush.SetActive(true);
                }
                
                Chase(Time.deltaTime/1.9f);
            }
            else
            {
                if (blush.activeSelf)
                {
                    blush.SetActive(false);
                }
                    Chase(Time.deltaTime);
            }

        }


	}
}
