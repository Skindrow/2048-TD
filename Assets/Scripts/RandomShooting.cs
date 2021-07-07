using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShooting : MonoBehaviour
{
    [SerializeField] private int countOfShoots;
    [SerializeField] private float forceOfShots;
    [SerializeField] private GameObject shot;
    [SerializeField] private float secBeforeShotsDestroyed;
    [SerializeField] private float timeToRecharge;
    [SerializeField] private GameObject rechargeBar;
    private bool isReady = true;

    private GameObject[] shotArray;


    private IEnumerator Shoot()
    {
        shotArray = new GameObject[countOfShoots];
        for (int i = 0; i < countOfShoots; i++)
        {
            shotArray[i] = Instantiate(shot, transform.position, Quaternion.identity);
            Rigidbody2D shotRB = shotArray[i].GetComponent<Rigidbody2D>();
            float x = Random.Range((transform.position.x - 1f), (transform.position.x + 1f));
            float y = Random.Range((transform.position.y - 1f), (transform.position.y + 1f));
            Vector2 rndVector = new Vector2(x, y) * forceOfShots;
            shotRB.AddForce(rndVector);
        }
        yield return new WaitForSeconds(secBeforeShotsDestroyed);

        for (int i = 0; i < countOfShoots; i++)
        {
            Destroy(shotArray[i]);
        }

    }

    public void ShootStart()
    {
        if (isReady)
        {
            StartCoroutine(Shoot());
            StartCoroutine(RechargeShooting());
        }
    }

    private IEnumerator RechargeShooting()
    {
        isReady = false;
        for (float i = 0; i < timeToRecharge; i += 0.1f)
        {
            rechargeBar.gameObject.transform.localScale = new Vector3(i / timeToRecharge, 1, 1);

            yield return new WaitForSeconds(0.1f);
        }
        isReady = true;
    }
}
