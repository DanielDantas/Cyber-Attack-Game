using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float moveSpeed = 10f;       // the Cloud's move speed

    private float horizontalMove = 0f;  // How much on the horizontal axes the Cloud should move
    private bool isMovingRight = true;  // Check if the Cloud is moving to the right direction
    private Rigidbody2D rigidbody2D;    // The Cloud's rigid body

    public GameObject Lock;
    public GameObject Firewall;
    private float[] offset = { -.5f, -.4f, -.2f, .2f, .4f, .5f };
    private float[] fade = { .75f, .79f, .8f, .9f, .98f, 1 };
    private int i = 0;
    private bool offsetForward = true;
    public Animator animator;

    public bool firewall = false;
    public bool encripted = false;



    // Start is called before the first frame update
    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
        // Set cloud to start moving to the right
        horizontalMove = moveSpeed;
        animator.speed = .1f;
    }

    // Update is called once per frame
    private void Update() {
        if (firewall)
        {
            Firewall.transform.position = this.transform.position;
            Firewall.GetComponent<SpriteRenderer>().enabled = true;
            Firewall.GetComponent<SpriteRenderer>().color = new Color(1, .5f, .5f, offset[i]);
        } else
        {
            Firewall.GetComponent<SpriteRenderer>().enabled = false;
        }

        if(encripted)
        {
            Lock.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + offset[i]);
            
            Lock.GetComponent<SpriteRenderer>().enabled = true;
        } else
        {
            Lock.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (offsetForward)
        {
            i++;
            if (i >= offset.Length)
            {
                i--;
                offsetForward = false;
            }
        }
        else
        {
            i--;
            if (i < 0)
            {
                i++;
                offsetForward = true;
            }
        }

    }

    private void FixedUpdate() {
        this.Move(horizontalMove * Time.fixedDeltaTime);

        // If the Cloud is way far to the left...
        if (transform.position.x <= -5f && !isMovingRight) {
            // ... flip the direction.
            Flip();
        }
        // Otherwise if the cloud is way far to the right...
        else if (transform.position.x >= 5f && isMovingRight) {
            // ... flip the direction.
            Flip();
        }
    }

    private void Move(float move) {
        rigidbody2D.velocity = new Vector2(move, rigidbody2D.velocity.y);
    }

    private void Flip() {
        // Switch the way the cloud is moving.
        isMovingRight = !isMovingRight;
        horizontalMove *= -1;
    }
}
