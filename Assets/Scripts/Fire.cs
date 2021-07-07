using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float timeToBurn = 1f;
    [SerializeField] private bool isFree = true;
    [SerializeField] private GameObject bar;
    [SerializeField] private ParticleSystem ps;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy onZone = collision.gameObject.GetComponent<Enemy>();
        if (onZone != null && onZone.readyForInteractions && isFree)
            StartCoroutine(EnemyBurn(onZone));
    }
    private IEnumerator EnemyBurn(Enemy enemy)
    {
        isFree = false;
        enemy.StopMoving();
        enemy.transform.position = transform.position;
        enemy.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        ps.Play();

        for (float i = 0; i < timeToBurn; i += 0.1f)
        {
            bar.gameObject.transform.localScale = new Vector3(i/timeToBurn,1,1);

            yield return new WaitForSeconds(0.1f);
        }
        ps.Stop();
        bar.gameObject.transform.localScale = new Vector3(0, 1, 1);


        ScoreCounter.Score += enemy.Value;


        Destroy(enemy.gameObject);



        isFree = true;
    }
}
