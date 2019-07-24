﻿using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    private int health = 23;
    public Sprite[] sprites;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (GameControllerObject != null) {
            gameController = GameControllerObject.GetComponent<GameController>();
        }
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

        if (health <= 0) {
            gameController.GameOverLoss();
        }
    }
}
