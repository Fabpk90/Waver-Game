using System.Collections.Generic;
using UnityEngine;


namespace Assets.FPSTesting.Utils
{
    public  class GameManager : MonoBehaviour
    {
        public int wave;

        public float time;

        public List<Player> listPlayer;

        public List<EnemyController> listEnemy;

        public EnemyController[] enemyType;

        public SpawnPoint[] enemySpawnPoints;


        private void Start()
        {
            listEnemy = new List<EnemyController>();

            GenerateWave(wave);
        }

        private void GenerateWave(int wave)
        {
            int enemies = Random.Range(1 * wave, wave * 3);

            int point;

            for(int i = 0; i < enemies + 1; ++i)
            {
                point = GetRandomSpawnPoint();
                
                while(enemySpawnPoints[point].IsUsed)
                {
                    point = GetRandomSpawnPoint();
                }

                enemySpawnPoints[point].Use();

                listEnemy.Add(Instantiate(enemyType[0], enemySpawnPoints[point].transform.position, Quaternion.identity) );

            }
        }

        private int GetRandomSpawnPoint()
        {
            return Random.Range(0, enemySpawnPoints.Length);
        }
    }
}
