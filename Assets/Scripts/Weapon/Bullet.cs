using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.Instance.addressablesObj.Spawn(1, gameObject.transform);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
