using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;    // The Item's rigid body
    public float startX;
    public float timeout;//30 frames a sec
    public float fadeTime;
    private float life;


    public ItemController(float startX, float timeout, float fadeTime)
    {
        this.startX = startX;
        this.timeout = timeout;
        life = timeout;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        this.transform.position.Set(startX, 10, 0);
        Debug.Log("Starting : " + gameObject.name + " : " + Time.time);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.tag == "Player")
        {
            Destroy(gameObject, .1f);
        }
        Debug.Log(otherObj.gameObject.name + " : " + gameObject.name + " : " + Time.time);
    }

    private void FixedUpdate()
    {
        if (life < fadeTime)
        {

        }

        timeout--;
    }

}
