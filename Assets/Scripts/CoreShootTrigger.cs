using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreShootTrigger : MonoBehaviour
{
    [SerializeField] RandomShooting corePoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy onZone = collision.gameObject.GetComponent<Enemy>();
        if (onZone != null)
            corePoint.ShootStart();
    }

    
}
