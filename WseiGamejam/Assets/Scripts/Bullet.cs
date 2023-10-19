using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("AutoDestroy");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForEndOfFrame();

        GetComponent<CircleCollider2D>().enabled = false;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
