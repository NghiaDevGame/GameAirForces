using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{

    [SerializeField]
    private float damage;
    [SerializeField]
    private AirHealth player;

    private void Start()
    {
        transform.Rotate(0, 0, 180);
        player = FindObjectOfType<AirHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.addressablesObj.Spawn(1, gameObject.transform);
            Destroy(gameObject);
            player.DamageToTrain(damage);
        }
        else if (collision.CompareTag("Limit"))
        {
            Destroy(gameObject);
        }
    }
}
