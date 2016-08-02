using UnityEngine;
using System.Collections;

public class JumpDetection : MonoBehaviour {

    public string tagToDetect = "Ground";
    public float jumpForce = 20.0f;
    private static Vector2 jump;
    public Transform groundCheck;
    public Transform damageCheck;
    public GameObject parent;
    private bool onGround = false;
    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private LayerMask whatIsPlayer;
    // Use this for initialization
    void Start () {
        jump = new Vector2(0, jumpForce);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.tag == tagToDetect || other.tag == "Player")
        //{
        //    GetComponentInParent<Rigidbody2D>().AddForce(jump);
        //}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //if (other.tag == tagToDetect)
        //{
            //searching = true;
            
        //}
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //Jump();
        Jump(other);
    }

    public void Jump()
    {
        if (onGround)
        {
            GetComponentInParent<Rigidbody2D>().AddForce(jump);
            onGround = false;
        }
    }


    void Jump(Collider2D other)
    {
        if (onGround && other.tag == tagToDetect)
        {
                GetComponentInParent<Rigidbody2D>().AddForce(jump);
            onGround = false;
        }
       
    }


    // Update is called once per frame
    private void FixedUpdate () {
        onGround = false;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, .1f, whatIsGround);

        for (int i = 0; i < colliders.Length; ++i)
        {
            if(colliders[i].gameObject != gameObject )//&& colliders[i].gameObject != GetComponentInParent<Transform>().gameObject)
            {
                onGround = true;
            }
        }

        colliders = Physics2D.OverlapCircleAll(damageCheck.position, .03f, whatIsPlayer);
        for (int i = 0; i < colliders.Length; ++i)
        {
            if (colliders[i].gameObject != gameObject)//&& colliders[i].gameObject != GetComponentInParent<Transform>().gameObject)
            {
                colliders[i].gameObject.SendMessage("SmallJump");
                parent.GetComponent<Animator>().Play("Death");
                Destroy(parent,0.15f);
            }
        }
    }
}
