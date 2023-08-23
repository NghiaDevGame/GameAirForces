using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirShooting : AirCtrl
{
    [SerializeField]
    private float fireRate = 5f;
    [SerializeField]
    protected List<Transform> weaponTip;

    float timeFire = 0;

    private void Update()
    {
        state = GameManager.Instance.playerState;
        if (state == PlayerState.MOVE)
        {
            Attack();
        }
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
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.weapon);

        for(int i = 0;i < weaponTip.Count; i++)
        {
            GameManager.Instance.addressablesObj.Spawn(0, weaponTip[i]);
            GameObject bullet = Instantiate(bulletPrefab, weaponTip[i].position, Quaternion.identity);
            Rigidbody2D rg = bullet.GetComponent<Rigidbody2D>();
            rg.AddForce(transform.up * this.force, ForceMode2D.Impulse);
        }
    }
}
