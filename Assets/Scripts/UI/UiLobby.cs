using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiLobby : UICanvas
{

    [Title("Button")] [SerializeField] private Button btnHide;
    [SerializeField] private Button btnEquip;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnDesc;
    [SerializeField] private Button btnMap;
    [SerializeField] private Button btnUpgrade;

    [Title("Text")]
    [SerializeField] private Text txtCoin;

    public Button BtnPlay => btnHide;

    // Start is called before the first frame update
    void Start()
    {
        btnEquip.onClick.AddListener(OnClickBtnEquip);
        btnSettings.onClick.AddListener(OnClickBtnSettings);
        btnDesc.onClick.AddListener(OnClickBtnDesc);
        btnMap.onClick.AddListener(OnClickBtnMap);
        btnUpgrade.onClick.AddListener(OnClickBtnUpgarde);
    }

    private void Update()
    {
        txtCoin.text = LobbyManager.Ins.Profile.GetGold() + "";
    }

    private void OnClickBtnUpgarde()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        LobbyManager.Ins.UIMainLobby.OpenUiAirTitle();
    }

    private void OnClickBtnMap()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        LobbyManager.Ins.UIMainLobby.OpenUIMap();
    }

    private void OnClickBtnDesc()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        LobbyManager.Ins.UIMainLobby.OpenUIDescription();
    }

    private void OnClickBtnSettings()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        LobbyManager.Ins.UIMainLobby.OpenUISettings();
    }

    private void OnClickBtnEquip()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        LobbyManager.Ins.UIMainLobby.OpenUIEquipAir();
    }

    public override void Show(bool _isShown, bool isHideMain = true)
    {
        base.Show(_isShown, isHideMain);

        if (!isShow)
        {
            return;
        }
    }
}
