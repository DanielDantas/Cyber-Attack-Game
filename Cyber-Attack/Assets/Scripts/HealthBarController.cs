using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    private int health = 23;
    public Sprite[] sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[23 - health];
        } 

    }

    public void hit(int damage)
    {
        health -= damage;
    }
}
