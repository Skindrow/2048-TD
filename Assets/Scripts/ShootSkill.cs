using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSkill : MonoBehaviour
{
    [SerializeField] private float skillRecharge;
    [SerializeField] private GameObject bar;
    [SerializeField] private RandomShooting shootPoint;

    private bool isReady = true;


    private IEnumerator Recharge()
    {
        isReady = false;
        for (float i = 0; i < skillRecharge; i += 0.1f)
        {
            bar.gameObject.transform.localScale = new Vector3(i / skillRecharge, 1, 1);

            yield return new WaitForSeconds(0.1f);
        }
        isReady = true;
    }
    private void OnMouseDown()
    {
        if (isReady)
        {
            shootPoint.ShootStart();
            StartCoroutine(Recharge());
        }
    }
}
