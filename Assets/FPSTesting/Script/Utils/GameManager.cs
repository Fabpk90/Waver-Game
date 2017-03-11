
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        public Canvas Inventory;

        public Text ammoText;
        public Text weaponName;

        private void Start()
        {
            listEnemy = new List<EnemyController>();

            GenerateWave(wave);
        }

        public void InitHUD(int magAmmo, int ammo, string weaponName)
        {
            ammoText.text = "" + magAmmo + "/" + ammo;
            this.weaponName.text = weaponName;
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

        public void ToggleInventory()
        {
            Inventory.enabled = !Inventory.enabled;
        }

        public void ShotFired(int magAmmo, int ammo)
        {
            ammoText.text = "" + magAmmo + "/" + ammo;
        }
    }
}
