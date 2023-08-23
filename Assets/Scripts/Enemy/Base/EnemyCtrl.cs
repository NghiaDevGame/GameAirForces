using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{

    private static EnemyCtrl ins;

    public float baseHealth;
    [SerializeField]
    protected float currentHealth;
    [SerializeField]
    protected DataAirEnemySO enemySO;
    [SerializeField]
    protected int idEnemy;
    public int count = 0;
    public int countEnemy = 0;
    [SerializeField]
    protected GameObject itemDrag;
    private int countDown = 1;

    [SerializeField]
    private TypeSpawnEnemy typeCheck;

    public static EnemyCtrl Ins { get => ins; set => ins = value; }

    private void Awake()
    {
        if (Ins == null)
            Ins = this;
    }

    // Use this for initialization
    protected virtual void Start()
    {
        currentHealth = baseHealth;
    }

    private void Update()
    {
        countEnemy = GameManager.Instance.CountEnemy;
        count = GameManager.Instance.Count;
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
        if (typeCheck == TypeSpawnEnemy.Boss)
        {
            GameManager.Instance.IncreaseLevel();
            GameManager.Instance.addressablesObj.Spawn(2, gameObject.transform);
            gameObject.SetActive(false);
            GameManager.Instance.UiManager.OpenUiWin(Constants.GOLD_WIN);
        }
        else
        {
            EnemyAction(GameManager.Instance.CountEnemy);
            gameObject.SetActive(false);
            countDown = 1;
        }
    }

    public void EnemyAction(float countSpawn)
    {
        if (count < countSpawn)
        {
            GameManager.Instance.Count += 1;
        }
    }
}
