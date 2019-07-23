using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public GameObject keys;
        public GameObject phishingKeys;
        public GameObject bricks;
        public GameObject enemies;
        public float gameTime = 0;

        public float phishingKeySpawnPercent; //(between 1-10) 10 = 100 percent spawn

        public CloudController cloudController;

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

        // Start is called before the first frame update
        private void Start() {
            GameObject GameControllerObject = GameObject.FindGameObjectWithTag("Cloud");
            if (GameControllerObject != null) {
                cloudController = GameControllerObject.GetComponent<CloudController>();
            }
            if (cloudController == null) {
                Debug.Log("Error accessing gameController");
            }
        }

        // Update is called once per frame
        private void Update() {
            gameTime += Time.deltaTime;

            if (gameTime - lastEnemySpawn > enemySpawnTime) {//we should use waves for this
                SpawnEnemy();
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
        }


        private void SpawnKey() {
            if (UnityEngine.Random.Range(0, 10) < phishingKeySpawnPercent)
            {
                Instantiate(phishingKeys, new Vector3(UnityEngine.Random.Range(-keyVector.x, keyVector.x), keyVector.y, keyVector.z), Quaternion.identity);
            } else
            {
                Instantiate(keys, new Vector3(UnityEngine.Random.Range(-keyVector.x, keyVector.x), keyVector.y, keyVector.z), Quaternion.identity);
            }
        }

        private void SpawnBrick() {
            Instantiate(bricks, new Vector3(UnityEngine.Random.Range(-brickVector.x, brickVector.x), brickVector.y, brickVector.z), Quaternion.identity);
        }

        private void SpawnEnemy() {
            Instantiate(enemies, new Vector3(UnityEngine.Random.Range(-enemyVector.x, enemyVector.x), enemyVector.y, enemyVector.z), Quaternion.identity);
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
    }
}
