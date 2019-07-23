﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health = 1;
    private bool bouncing = false;
    private Vector3 lastPos;

    // Start is called before the first frame update
    private void Start() {

    }

    private void fixedUpdate()
    {
        
    }

    // Update is called once per frame
    private void Update() {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (bouncing)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x+(transform.position.x-lastPos.x), transform.position.y + (transform.position.y - lastPos.y)), ForceMode2D.Impulse);
        }

        lastPos = transform.position;
    }

    public void TakeDamage(int damage) {
        Health -= damage;

        if (Health <= 0) {
            Die();
        }
    }

    public void Die() {
        Destroy(gameObject);

        GameObject gameControllerObject = GameObject.Find("GameController");
        if (gameControllerObject != null) {
            GameController gameController = gameControllerObject.GetComponent<GameController>();
            gameController.UpdateEnemyNumber(-1);
        } 
    }

    public void Bounce()
    {
        bouncing = true;
        
    }
}
