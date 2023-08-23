using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{

    [SerializeField]
    protected Vector2 moveDirection;
    [SerializeField]
    private float damage;
    [SerializeField]
    protected float moveSpeed = 5f;
    [SerializeField]
    private AirHealth player;

    private void Start()
    {
        transform.Rotate(0, 0, 180);
        player = FindObjectOfType<AirHealth>();
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
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
