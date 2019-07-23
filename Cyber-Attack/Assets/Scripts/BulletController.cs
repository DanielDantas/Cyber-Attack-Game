using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed = 20f;
    public int Damage = 1;
    public Sprite Zero;
    public Sprite One;
    public GameObject ImpactEffect;
    public Rigidbody2D BulletRB;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sprite == null) {
            spriteRenderer.sprite = Zero;
        }
        ChangeSprite();

        BulletRB.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        var enemy = collision.GetComponent<EnemyController>();
        if (enemy != null) {
            enemy.TakeDamage(Damage);
        }

        Instantiate(ImpactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    private void ChangeSprite() {
        System.Random rand = new System.Random();

        if (rand.Next(0, 2) == 0) {
            spriteRenderer.sprite = Zero;
        } else {
            spriteRenderer.sprite = One;
        }
    }
}
