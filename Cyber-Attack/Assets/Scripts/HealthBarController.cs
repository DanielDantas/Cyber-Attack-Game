using Assets.Scripts;
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
        else
        {
            GetComponent<SpriteRenderer>().sprite = sprites[22];
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
