using Assets.Scripts;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int Health = 1;
    private bool bouncing = false;
    private Vector3 lastPos;
    public int type;
    

    public Animator Animator;
    private GameController gameController;

    // Start is called before the first frame update
    private void Start() {
        GameObject GameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (GameControllerObject != null) {
            gameController = GameControllerObject.GetComponent<GameController>();
        }
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
        gameController?.UpdateEnemyNumber(-1);
    }

    public void explode()
    {
        Destroy(gameObject);
    }

    public void Bounce()
    {
        bouncing = true;    
    }

    public void setType(int i)
    {
        type = i;
        Animator.SetInteger("enemyType", i);
        switch (i)
        {
            case 0:
                Health = 2;
                transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = 5;
                break;
            case 1:
                Health = 5;
                transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = 3;
                break;
            case 2:
                Health = 10;
                transform.parent.gameObject.GetComponent<AIPath>().maxSpeed = 1;
                break;
        }
    }
}
