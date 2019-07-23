using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Assets.Scripts
{

    public class ItemController : MonoBehaviour
    {
        private Rigidbody2D rigidbody2D;    // The Item's rigid body
        public SpriteRenderer img;
        public GameController gameController;
        public float spawnTime;

        // Start is called before the first frame update
        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            img = GetComponent<SpriteRenderer>();
            spawnTime = 10;
            Debug.Log("Spawned : " + gameObject.name + " : " + Time.time);
            GameObject GameControllerObject = GameObject.FindGameObjectWithTag("GameController");
            if(GameControllerObject != null)
            {
                gameController = GameControllerObject.GetComponent<GameController>();
            }
            if(gameController == null)
            {
                Debug.Log("Error accessing gameController");
            }
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D otherObj)
        {
            if (otherObj.gameObject.tag == "Player")
            {
                if (this.tag == "Key")
                {
                    gameController.encriptData();
                }
                else if(this.tag == "Brick")
                {
                    gameController.firewall();
                }
                Destroy(gameObject, .1f);
            }

        }

        private void FixedUpdate()
        {
            spawnTime -= Time.deltaTime;
            //animator.SetFloat("spawnTime", spawnTime);
            if (spawnTime < 0)
            {
                Destroy(gameObject, .1f);
            }
            else if (spawnTime < 5)
            {
                StartCoroutine(FadeImage());
            }
        }


        IEnumerator FadeImage()
        {
            // loop over 1 second backwards
            for (float i = 5; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }

        }

    }
}
