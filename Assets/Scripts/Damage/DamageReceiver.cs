using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : MonoBehaviour
{

    [SerializeField]
    protected bool isDead = false;
    [SerializeField]
    protected float hp = 1;
    [SerializeField]
    protected float maxHp = 1;

    public float MaxHp { get => maxHp; set => maxHp = value; }

    protected void OnEnable()
    {
        this.Rebord();
    }

    protected void ResetValue()
    {
        this.Rebord();
    }

    protected virtual void Rebord()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    public virtual void Add(float add)
    {
        if (this.isDead) return;
        this.hp += add;
        if (this.hp > this.maxHp) this.hp = this.maxHp;
    }

    public virtual void Deduct(float deduct)
    {
        if (this.isDead) return;

        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
