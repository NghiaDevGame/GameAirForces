using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSupport : MonoBehaviour
{

    [SerializeField]
    private float fireRate = 5f;
    [SerializeField]
    private List<GameObject> shooting;
    [SerializeField]
    private Transform weaponTip;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float force = 50;

    float timeFire = 0;

    private void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (fireRate == 0)
        {
            Shoot();
        }
        else
        {
            if (Time.time > timeFire)
            {
                timeFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameManager.Instance.addressablesObj.Spawn(0, weaponTip);
        GameObject bullet = Instantiate(bulletPrefab, weaponTip.position, Quaternion.identity);
        Rigidbody2D rg = bullet.GetComponent<Rigidbody2D>();
        rg.AddForce(transform.up * this.force, ForceMode2D.Impulse);
    }
}
