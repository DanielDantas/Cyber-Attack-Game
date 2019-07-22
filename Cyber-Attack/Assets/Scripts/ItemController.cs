using UnityEngine;
using UnityEngine.Events;

public class ItemController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;    // The Item's rigid body
    public float spawnTime;


    // Start is called before the first frame update
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spawnTime = 10;
        Debug.Log("Spawned : " + gameObject.name + " : " + Time.time);
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
        
    }

    private void FixedUpdate()
    {
        spawnTime -= Time.deltaTime;
        if(spawnTime < 0)
        {
            Destroy(gameObject, .1f);
        }
    }

}
