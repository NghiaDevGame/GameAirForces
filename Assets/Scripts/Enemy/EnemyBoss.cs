using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : EnemyCtrl
{

    [SerializeField]
    private float delayRoll = 3f;
    private float curdelayRoll;
    [SerializeField]
    private int countEnemyChild = 50;
    [SerializeField]
    private float delayShoot;
    private float curShoot;
    [SerializeField]
    private List<Transform> listPos;
    [SerializeField]
    private int bulletsAmout = 20;
    [SerializeField]
    private float startAngle, endAngle;

    //shoot
    private float angle = 0f;

    [SerializeField]
    private float timer = 3f;
    [SerializeField]
    private GameObject bulletHell;
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private int idBulletHell;

    [SerializeField]
    private Slider sliderHealth;

    private void OnEnable()
    {
        //GameManager.Instance.UiManager.OpenPopupWarningBoss();
    }

    protected override void Start()
    {
        curShoot = delayShoot;
        curdelayRoll = delayRoll;
        //data
        this.baseHealth = this.enemySO.GetEnemyByID(this.idEnemy).maxHealth;
        this.bullet = this.enemySO.GetEnemyByID(this.idEnemy).bullet;

        sliderHealth.value = baseHealth;
        sliderHealth.maxValue = baseHealth;
        this.CheckShootIdBulletHell();
        base.Start();
    }

    private void Update()
    {
        sliderHealth.value = currentHealth;

        curdelayRoll -= Time.deltaTime;
        if (curdelayRoll > 0f) return;
        transform.DOMoveY(3.15f, 1f);

        //bullet hell
        this.Attack();
        Shooting();
    }

    private void AttackCircleBullet()
    {
        InvokeRepeating("FireHell", 0f, 0.1f);
    }

    private void AttackCircleBullet2()
    {
        InvokeRepeating("FireEnemyHell2", 0f, 2f);
    }

    private void Attack()
    {
        this.timer -= Time.deltaTime;
        if (this.timer >= 2f)
        {
            InvokeRepeating("FireEnemyHell", 0f, 0.1f);
        }
        else if (this.timer < 1f)
        {
            CancelInvoke("FireEnemyHell");
            if (this.timer <= 0f)
            {
                countEnemy = 0;
                this.timer = 3f;
            }
        }
    }

    private void FireEnemyHell()
    {
        for (int i = 0; i <= 1; i++)
        {
            if (countEnemy > countEnemyChild) return;
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f);

            Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMove - transform.position).normalized;

            GameObject bulletFabs = Instantiate(bulletHell, transform.position, Quaternion.identity);
            bulletFabs.transform.position = transform.position;
            bulletFabs.transform.rotation = transform.rotation;
            bulletFabs.GetComponent<BulletHell>().SetMoveDirection(bulDir);
            angle += 10f;
            countEnemy++;
        }

        angle += 10f;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

    private void FireEnemyHell2()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmout;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmout + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMove - transform.position).normalized;

            GameObject bulletFabs = Instantiate(bulletHell, transform.position, Quaternion.identity);
            bulletFabs.transform.position = transform.position;
            bulletFabs.transform.rotation = transform.rotation;
            bulletFabs.GetComponent<BulletHell>().SetMoveDirection(bulDir);
            angle += angleStep;
        }
    }

    private void FireHell()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMove = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMove - transform.position).normalized;

        GameObject bulletFabs = Instantiate(bulletHell, transform.position, Quaternion.identity);
        bulletFabs.transform.position = transform.position;
        bulletFabs.transform.rotation = transform.rotation;
        bulletFabs.GetComponent<BulletHell>().SetMoveDirection(bulDir);
        angle += 10f;
    }

    private void Shooting()
    {
        curShoot -= Time.deltaTime;
        if (curShoot <= 0f)
        {
            for(int i = 0; i < listPos.Count;i++)
            {
                GameObject bulletFabs = Instantiate(bullet, listPos[i].position, Quaternion.identity);
                Rigidbody2D rg = bulletFabs.GetComponent<Rigidbody2D>();
                rg.AddForce(Vector2.down * 3.5f, ForceMode2D.Impulse);
                curShoot = delayShoot;
            }
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

    private void CheckShootIdBulletHell()
    {
        if(idBulletHell == 1)
        {
            this.AttackCircleBullet();
        }
        else if(idBulletHell == 2)
        {
            this.AttackCircleBullet2();
        }
        else
        {
            this.AttackCircleBullet();
            this.AttackCircleBullet2();
        }
    }
}
