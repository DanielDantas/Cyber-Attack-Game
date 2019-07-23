using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed = 20f;
    public Rigidbody2D BulletRB;

    // Start is called before the first frame update
    void Start()
    {
        BulletRB.velocity = transform.right * Speed;    
    }
}
