using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirHealth : AirCtrl
{

    [SerializeField]
    private float curDelay = 0.2f;
    private int countOpen = 1;
    [SerializeField]
    protected float maxhealth;
    [SerializeField]
    private float curHealth;

    private void Start()
    {
        maxhealth = data.GetAirByID(id).maxHealth;
        curHealth = maxhealth;
        GameManager.Instance.UiManager.UiGamePlay.ImgHealth.maxValue = curHealth; 
        GameManager.Instance.UiManager.UiGamePlay.ImgHealth.value = curHealth; 
    }

    private void Update()
    {
        GameManager.Instance.UiManager.UiGamePlay.ImgHealth.value = curHealth;
    }

    public void DamageToTrain(float damage)
    {
        curHealth -= damage;

        if (curHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (countOpen <= 0f) return;
        countOpen--;
        GameManager.Instance.addressablesObj.Spawn(2, gameObject.transform);
        gameObject.SetActive(false);
        LevelManager.Instance.EndGame(LevelResult.Lose);
    }
}
