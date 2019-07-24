using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public GameObject keys;
        public GameObject phishingKeys;
        public GameObject bricks;
        public GameObject enemies;
        public GameObject enter;
        public float gameTime = 0;

        public float phishingKeySpawnPercent; //(between 1-10) 10 = 100 percent spawn

        public CloudController cloudController;
        private HeroController heroController;

        public float encriptTime;
        public float lastEncript = 0;
        public float firewallTime;
        public float lastFirewall = 0;

        public Vector3 keyVector;
        public float keySpawnTime;
        public float lastKeySpawn = 0;
        public Vector3 brickVector;
        public float brickSpawnTime;
        public float lastBrickSpawn = 0;
        public Vector3 enemyVector;
        public float enemySpawnTime;
        public float lastEnemySpawn = 0;
        public int[] numberEachEnemy = { 5, 20, 10 };

        private int enemyNumber = 0;

        private bool isGameOver = false;

        // Start is called before the first frame update
        private void Start() {
            GameObject GameControllerObject = GameObject.FindGameObjectWithTag("Cloud");
            if (GameControllerObject != null) {
                cloudController = GameControllerObject.GetComponent<CloudController>();
            }
            if (cloudController == null) {
                Debug.Log("Error accessing gameController");
            }

            GameObject heroGameObject = GameObject.FindGameObjectWithTag("Player");
            if (heroGameObject != null) {
                heroController = heroGameObject.GetComponent<HeroController>();
            }
            Time.timeScale = 1;

            enemyNumber = numberEachEnemy.Sum();
        }

        // Update is called once per frame
        private void Update() {
            if (!isGameOver) {
                GameControl();
            }
        }

        private void GameControl() {
            gameTime += Time.deltaTime;

            if (gameTime - lastEnemySpawn > enemySpawnTime) {//we should use waves for this
                bool found = false;
                int spawn = 0;
                while (!found) {
                    spawn = UnityEngine.Random.Range(0, 3);
                    if (numberEachEnemy[spawn] != 0) {
                        found = true;
                        Debug.Log("Spawning " + spawn);
                    }
                }
                SpawnEnemy(spawn);
                numberEachEnemy[spawn] -= 1;
                lastEnemySpawn = gameTime;
            }

            if (cloudController.encripted && gameTime - lastEncript > encriptTime) {
                cloudController.encripted = false;
                lastKeySpawn = gameTime;
            }

            if (!cloudController.encripted && gameTime - lastKeySpawn > keySpawnTime) {
                SpawnKey();
                lastKeySpawn = gameTime;
            }

            if (cloudController.firewall && gameTime - lastFirewall > firewallTime) {
                cloudController.firewall = false;
                lastBrickSpawn = gameTime;
            }

            if (!cloudController.firewall && gameTime - lastBrickSpawn > brickSpawnTime) {
                SpawnBrick();
                lastBrickSpawn = gameTime;
            }

            if (enemyNumber <= 0) {
                GameOverWin();
            }
        }

        private void SpawnKey() {
            if (UnityEngine.Random.Range(0, 10) < phishingKeySpawnPercent) {
                Instantiate(phishingKeys, new Vector3(UnityEngine.Random.Range(-keyVector.x, keyVector.x), keyVector.y, keyVector.z), Quaternion.identity);
            } else {
                Instantiate(keys, new Vector3(UnityEngine.Random.Range(-keyVector.x, keyVector.x), keyVector.y, keyVector.z), Quaternion.identity);
            }
        }

        private void SpawnBrick() {
            Instantiate(bricks, new Vector3(UnityEngine.Random.Range(-brickVector.x, brickVector.x), brickVector.y, brickVector.z), Quaternion.identity);
        }

        private void SpawnEnemy(int type) {
            float side = UnityEngine.Random.Range(0, 3);
            GameObject enemy;
            switch (side)
            {
                case 0:
                    enemy = Instantiate(enemies, new Vector3(-15, UnityEngine.Random.Range(enemyVector.y,0), enemyVector.z), Quaternion.identity);
                    break;
                case 2:
                    enemy = Instantiate(enemies, new Vector3(15, UnityEngine.Random.Range(enemyVector.y,0), enemyVector.z), Quaternion.identity);
                    break;
                default:
                    enemy = Instantiate(enemies, new Vector3(UnityEngine.Random.Range(-enemyVector.x, enemyVector.x), enemyVector.y, enemyVector.z), Quaternion.identity);
                    break;
                
            }
            enemy.GetComponentInChildren<EnemyController>().setType(type);
        }

        public void encriptData() {
            cloudController.encripted = true;
            lastEncript = gameTime;
            Debug.Log("Encripted");
        }

        public void firewall() {
            cloudController.firewall = true;
            lastFirewall = gameTime;
            Debug.Log("Flame On");
        }

        public void phish() {
            cloudController.HealthBar.GetComponent<HealthBarController>().hit(1);
        }

        public void GameOverWin() {
            heroController?.SetWinner();
            cloudController.GameOverMode(isWinner: true);
            GameOver();
        }

        public void GameOverLoss() {
            heroController?.SetLooser();
            cloudController.GameOverMode(isWinner: false);
            GameOver();
        }

        private void GameOver() {
            isGameOver = true;

            StartCoroutine(wait1());
            /*var gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var g in gameObjects) {
                Destroy(g);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("Key");
            foreach (var g in gameObjects) {
                Destroy(g);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("PKey");
            foreach (var g in gameObjects) {
                Destroy(g);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("Brick");
            foreach (var g in gameObjects) {
                Destroy(g);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("CloudFireFlicker");
            foreach (var g in gameObjects) {
                Destroy(g);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("Lock");
            foreach (var g in gameObjects) {
                Destroy(g);
            }
            gameObjects = GameObject.FindGameObjectsWithTag("A*");
            foreach (var g in gameObjects) {
                Destroy(g);
            }*/

            //Destroy(gameObject);
            StartCoroutine(EnterToContinue());
        }

        IEnumerator EnterToContinue()
        {
            
             yield return new WaitForSecondsRealtime(5);
             SceneManager.LoadSceneAsync("Intro");

        }
        IEnumerator wait1()
        {

            yield return new WaitForSecondsRealtime(1);
            Time.timeScale = 0;

        }


        public void UpdateEnemyNumber(int increment) {
            enemyNumber += increment;
        }
    }
}
