using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health = 1;

    // Start is called before the first frame update
    private void Start() {

    }

    // Update is called once per frame
    private void Update() {

    }

    public void TakeDamage(int damage) {
        Health -= damage;

        if (Health <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
