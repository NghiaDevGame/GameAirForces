using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAir : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BulletEnemy"))
        {
            GameManager.Instance.addressablesObj.Spawn(3, collision.gameObject.transform);
            Destroy(collision.gameObject);
        }
    }
}
