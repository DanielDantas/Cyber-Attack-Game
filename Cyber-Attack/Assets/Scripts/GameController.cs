using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameController: MonoBehaviour
    {
        public GameObject keys;
        public GameObject bricks;
        public float gameTime = 0;

        public CloudController cloudController;

        public float encriptTime;
        public float lastEncript = 0;
        public float lastFirewall = 0;

        public Vector3 keyVector;
        public float keySpawnTime;
        public float lastSpawn = 0;
        
        // Start is called before the first frame update
        private void Start()
        {
            GameObject GameControllerObject = GameObject.FindGameObjectWithTag("Cloud");
            if (GameControllerObject != null)
            {
                cloudController = GameControllerObject.GetComponent<CloudController>();
            }
            if (cloudController == null)
            {
                Debug.Log("Error accessing gameController");
            }
        }

        // Update is called once per frame
        private void Update()
        {
            gameTime += Time.deltaTime;
            
            if(cloudController.encripted && gameTime - lastEncript > encriptTime)
            {
                cloudController.encripted = false;
                lastSpawn = gameTime;//Forces time without encription
            }

            if(!cloudController.encripted && gameTime - lastSpawn > keySpawnTime)
            { 
                SpawnKey();
                lastSpawn = gameTime;
            }
        }


        private void SpawnKey()
        {
             Instantiate(keys, new Vector3(UnityEngine.Random.Range(-keyVector.x,keyVector.x), keyVector.y, keyVector.z), Quaternion.identity);           
        }

        public void encriptData()
        {
            cloudController.encripted = true;
            lastEncript = gameTime;
            Debug.Log("Encripted");
        }

        public void firewall()
        {
            cloudController.encripted = true;
            lastFirewall = gameTime;
            Debug.Log("Encripted");
        }
    }
}
