using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : LevelManager
{

    [Title("Button")]
    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnDefense;
    [SerializeField] private Button btnSkill;
    [Title("Text")]
    [SerializeField] private Text txtCoin;
    [SerializeField] private Text txtLevel;

    [SerializeField] private Image imgLock1;
    [SerializeField] private Image imgLock2;

    [Title("Image Health")]
    [SerializeField]
    private Slider imgHealth;

    public Slider ImgHealth { get => imgHealth; set => imgHealth = value; }
    public Image ImgLock1 { get => imgLock1; set => imgLock1 = value; }
    public Image ImgLock2 { get => imgLock2; set => imgLock2 = value; }

    private float countDown1 = 0.0001f;
    private float countDown2 = 0.0002f;

    protected void Start()
    {
        btnPause.onClick.AddListener(OnClickBtnPause);
        btnDefense.onClick.AddListener(OnClickOpenDefense);
        btnSkill.onClick.AddListener(OnClickOpenSkill);
    }

    private void OnClickOpenSkill()
    {

    }

    private void OnClickOpenDefense()
    {

    }

    private void Update()
    {
        OpenSkill();
        //txtLevel.text = "Level " + GameManager.Instance.CurrentLevel;
        if (GameManager.Instance.Count >= GameManager.Instance.CountEnemy)
        {
            EndGame(LevelResult.Win);
            WaveSpawn.Instance.DelayedDestroyLevel();
        }

        if(Input.GetKey(KeyCode.Space))
        {
            GameManager.Instance.Pause();
            GameManager.Instance.UiManager.OpenPopupPause();
        }
    }

    private void OnClickBtnPause()
    {
        GameManager.Instance.Pause();
        GameManager.Instance.UiManager.OpenPopupPause();
    }

    public override void StartLevel()
    {
        throw new NotImplementedException();
    }

    private void OpenSkill()
    {
        imgLock1.fillAmount -= countDown1;
        imgLock2.fillAmount -= countDown2;
    }
}
