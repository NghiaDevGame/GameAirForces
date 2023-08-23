using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyCtrl
{

    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    private float delayShoot;
    private float curShoot;
    [SerializeField]
    private Transform firePos;

    [Title("State")]
    [SerializeField]
    private EnemyState enemyState;
    [SerializeField]
    private Transform pointFx;

    protected override void Start()
    {
        transform.Rotate(0, 0, 180);
        curShoot = delayShoot;
        this.baseHealth = this.enemySO.GetEnemyByID(this.idEnemy).maxHealth;
        this.bullet = this.enemySO.GetEnemyByID(this.idEnemy).bullet;
        base.Start();
    }

    private void Update()
    {
        enemyState = GameManager.Instance.enemyState;
    }

    private void FixedUpdate()
    {
        if (enemyState == EnemyState.SHOOTING)
        {
            Shooting();
        }
    }

    private void Shooting()
    {
        curShoot -= Time.deltaTime;
        if (curShoot <= 0f)
        {
            GameObject bulletFabs = Instantiate(bullet, firePos.position, Quaternion.identity);
            Rigidbody2D rg = bulletFabs.GetComponent<Rigidbody2D>();
            rg.AddForce(transform.up * 3.5f, ForceMode2D.Impulse);

            curShoot = delayShoot;
        }
        else
        {
            curShoot -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Damage(AirCtrl.Instance.Damage);
        }
    }

}
