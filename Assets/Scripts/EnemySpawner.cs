using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int enemiesSpawnAtTick;
    [SerializeField] private float tick;
    [SerializeField] private GameObject enemy;
    [Header("Difficulty Progression")]
    [SerializeField] float secForTickReduce;
    [SerializeField] float tickReduce;
    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(DifficultyProgression());
    }

    private IEnumerator EnemySpawn()
    {
        while (true)
        {
            for (int i = 0; i < enemiesSpawnAtTick; i++)
            {
                int side = 1;
                bool horizontalConst = true;

                int rnd = Random.Range(0, 2);
                if (rnd == 0)
                    horizontalConst = false;
                rnd = Random.Range(0, 2);
                if (rnd == 0)
                    side = -1;
                if (horizontalConst)
                    Instantiate(enemy, new Vector3(Random.Range(-11f, 11f), 6 * side, 0f), Quaternion.identity);
                else
                    Instantiate(enemy, new Vector3(11f * side, Random.Range(-6, 6), 0f), Quaternion.identity);
            }
            yield return new WaitForSeconds(tick);
        }
    }

    private IEnumerator DifficultyProgression()
    {
        while (tick >= 0.2f)
        {
            yield return new WaitForSeconds(secForTickReduce);
            tick -= tickReduce;
        }
        
    }

}
