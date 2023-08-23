using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.5f;
    public float baseHealth;
    [SerializeField]
    float currentHealth;
    private int countDown = 1;
    public int count = 0;

    protected virtual void Start()
    {
        currentHealth = baseHealth;
    }

    private void Update()
    {
        count = GameManager.Instance.Count;
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Damage(10);
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (countDown == 1)
            {
                Die();
                countDown--;
            }
        }
    }

    void Die()
    {
        GameManager.Instance.addressablesObj.Spawn(2, gameObject.transform);
        EnemyAction(GameManager.Instance.CountEnemy);
        gameObject.SetActive(false);
        countDown = 1;
    }

    public void EnemyAction(float countSpawn)
    {
        if (count < countSpawn)
        {
            GameManager.Instance.Count += 1;
        }
    }
}
