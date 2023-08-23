using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameManager.Instance.addressablesObj.Spawn(1, gameObject.transform);
        }
        else if (collision.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
