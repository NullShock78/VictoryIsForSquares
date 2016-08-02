using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class EnemyPatrolAI : MonoBehaviour {



    public string tagToDetect = "Player";
    public float x_moveSpeed = 9f;
    public Transform[] patrolNodes;
    private float[] patrolPos_xS;
    private bool aggroed = false;
    //private bool searching = false;
    //private float timeOut = 0.0f;
    private const float MAX_WAIT = 3000.0f;
    private float x_pos = 0;
    private float updateTime = 0.0f;
    private const float MAX_UPDATE_TIME = 200.0f;
    private Vector3 movement;
    private const float bufferSize = .03f;
    public float currentNodePos = 0;
    public int currentNodeIndex = 0;
    public int nodeListLen = 0;
    public float diff = 0;

    // Use this for initialization
    void Start()
    {
        movement = new Vector3(x_moveSpeed, 0, 0);
        nodeListLen = patrolNodes.Length;
        this.patrolPos_xS = new float[nodeListLen];

        for (int j = 0; j < nodeListLen; ++j)
        {
            patrolPos_xS[j] = patrolNodes[j].position.x;
        }

        currentNodePos = patrolPos_xS[0];



        if (currentNodePos < transform.position.x)
        {
            movement.x = -x_moveSpeed;
        }
        else
        {
            movement.x = x_moveSpeed;
        }
    }

    private void Awake()
    {
       
        
    }

    void Move(float dt)
    {
        transform.Translate((movement.x * dt) / 10.0f, 0, 0);
    }

    void CheckFlip()
    {
        movement.x = -movement.x;
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
    void FixedUpdate()
    {

       if (aggroed)
        {
            if (x_pos < transform.position.x)
            {
                movement.x = -x_moveSpeed;
            }
            else
            {
                movement.x = x_moveSpeed;
            } 

        }
       else
        {
            diff = transform.position.x - currentNodePos;
            if(diff < 0)
            {
                diff = -diff;
            }
            if (diff <= bufferSize)
            {
                currentNodeIndex = (currentNodeIndex == nodeListLen - 1)? 0 : currentNodeIndex + 1;
                currentNodePos = patrolPos_xS[currentNodeIndex];
                CheckFlip();
            }


        }

        Move(Time.deltaTime);
    }
}