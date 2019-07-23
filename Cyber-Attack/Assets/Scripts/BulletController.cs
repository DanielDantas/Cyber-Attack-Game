using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed = 20f;
    public int Damage = 1;
    public Rigidbody2D BulletRB;

    // Start is called before the first frame update
    void Start()
    {
        BulletRB.velocity = transform.right * Speed;    
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var enemy = collision.GetComponent<EnemyController>();
        enemy?.TakeDamage(Damage);
        Destroy(gameObject);
    }
}
