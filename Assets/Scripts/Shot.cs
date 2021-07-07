using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy onZone = collision.gameObject.GetComponent<Enemy>();
        if (onZone != null)
            KillEnemy(onZone);
    }
    private void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
        ScoreCounter.Score += enemy.Value;
    }
}
