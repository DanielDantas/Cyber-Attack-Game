using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;    // The Cloud's rigid body
    private Transform transform;
    private float startX;
    private float timeout;


    public ItemController(float startX, float timeout)
    {
        this.startX = startX;
        this.timeout = timeout;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        transform.position.Set(startX, 10, 0);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }

    private void Move(float move)
    {
        rigidbody2D.velocity = new Vector2(move, rigidbody2D.velocity.y);
    }

    private void Flip()
    {
        // Switch the way the cloud is moving.
        //isMovingRight = !isMovingRight;
        //horizontalMove *= -1;
    }
}
