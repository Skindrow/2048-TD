using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public bool readyForInteractions = false;

    [SerializeField] private int value = 1;
    [SerializeField] public float speed = 0.5f;
    [SerializeField] GameObject particles;
    [SerializeField] Text valueText;

    public int Value
    {
        get { return value; }
    }

    private void Start()
    {
        valueText.text = value.ToString();
        StartCoroutine(MoveTo(new Vector2(0f, 0f)));
    }

    private IEnumerator MoveTo(Vector2 movePos)
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePos, speed / 100);
            yield return new WaitForFixedUpdate();
        }
    }
    public void StopMoving ()
    {
        StopAllCoroutines();
    }


    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
    private void OnMouseUp()
    {
        StartCoroutine(Interaction());
    }

    private IEnumerator Interaction()
    {
        readyForInteractions = true;
        yield return new WaitForSeconds(0.1f);
        readyForInteractions = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy onZone = collision.gameObject.GetComponent<Enemy>();
        if (onZone != null && readyForInteractions && onZone.value == this.value)
            Unite(onZone);
    }
    private void Unite(Enemy other)
    {
        value += other.value;
        Destroy(other.gameObject);
        valueText.text = value.ToString();
        Destroy(Instantiate(particles, transform.position, Quaternion.identity), 3f);
    }
}
