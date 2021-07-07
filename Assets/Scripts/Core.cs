using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy onZone = collision.gameObject.GetComponent<Enemy>();
        if (onZone != null)
            TakeDamage(1, onZone);
    }
    private void TakeDamage(int i, Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
