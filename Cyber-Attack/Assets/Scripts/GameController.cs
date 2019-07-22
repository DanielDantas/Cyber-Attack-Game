using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class GameController: MonoBehaviour
    {
        public GameObject keys;
        public float gameTime = 0;
        public Vector3 keyVector;
        public float keySpawnTime;
        private float lastSpawn = 0;
        
        // Start is called before the first frame update
        private void Start()
        {
            
        }

        // Update is called once per frame
        private void Update()
        {
            gameTime += Time.deltaTime;
            
            if(gameTime - lastSpawn > keySpawnTime)
            { 
                SpawnKey();
                lastSpawn = gameTime;
            }
        }

        private void SpawnKey()
        {
             Instantiate(keys, new Vector3(UnityEngine.Random.Range(-keyVector.x,keyVector.x), keyVector.y, keyVector.z), Quaternion.identity);           
        }
    }
}
