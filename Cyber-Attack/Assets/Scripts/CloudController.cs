using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float moveSpeed = 10f;       // the Cloud's move speed

    private float horizontalMove = 0f;  // How much on the horizontal axes the Cloud should move
    private bool isMovingRight = true;  // Check if the Cloud is moving to the right direction
    private Rigidbody2D rigidbody2D;    // The Cloud's rigid body

    // Start is called before the first frame update
    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
        // Set cloud to start moving to the right
        horizontalMove = moveSpeed;
    }

    // Update is called once per frame
    private void Update() {

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
