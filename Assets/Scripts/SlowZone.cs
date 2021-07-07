using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    [SerializeField] private float slowDown = 0.5f;
    [SerializeField] private int maxCountOfZones;
    [SerializeField] private bool isDuplicated = true;
    [SerializeField] private float radiusOfAff;
    [SerializeField] private float secOfExisting;

    private GameObject[] zones;
    private void Start()
    {
        if (isDuplicated)
        {
            int rnd = Random.Range(0, maxCountOfZones);
            zones = new GameObject[rnd + 1];
            zones[rnd] = gameObject;

            GameObject nonDuplZone = gameObject;
            nonDuplZone.GetComponent<SlowZone>().isDuplicated = false;

            for (int i = 0; i < rnd; i++)
            {
                Vector3 rndPos = new Vector3(transform.position.x + Random.Range(-radiusOfAff, radiusOfAff), transform.position.y + Random.Range(-radiusOfAff, radiusOfAff), -2f);
                GameObject zoneGO = Instantiate(nonDuplZone, rndPos, Quaternion.identity);
                float rndF = Random.Range(0f, 0.5f * transform.localScale.x);
                zoneGO.transform.localScale = new Vector3(rndF, rndF, 1);
                zones[i] = zoneGO;
            }
            StartCoroutine(DeleteZones());
        }
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy onZone = collision.gameObject.GetComponent<Enemy>();
        if (onZone != null)
            onZone.speed *= slowDown;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy onZone = collision.gameObject.GetComponent<Enemy>();
        if (onZone != null)
            onZone.speed /= slowDown;
    }
    private IEnumerator DeleteZones ()
    {
        yield return new WaitForSeconds(secOfExisting);
        for (int i = 0; i < zones.Length; i++)
        {
            Destroy(zones[i].gameObject);
        }
    }
}
