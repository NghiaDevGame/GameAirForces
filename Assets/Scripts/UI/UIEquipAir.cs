using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipAir : UICanvas
{

    [Title("Button")] [SerializeField] private Button btnHide;
    [SerializeField] private Button btnExit;
    [SerializeField] private List<Button> btnEquips;
    [SerializeField] private List<Sprite> imgAir;
    [SerializeField] private List<Image> OpenEquips;

    public Button BtnPlay => btnHide;

    void Start()
    {
        btnExit.onClick.AddListener(OnClickBtnExit);
        btnEquips[0].onClick.AddListener(OnClickBtnEquip0);
        btnEquips[1].onClick.AddListener(OnClickBtnEquip1);
        btnEquips[2].onClick.AddListener(OnClickBtnEquip2);
        btnEquips[3].onClick.AddListener(OnClickBtnEquip3);
        CheckOpenEquip();
    }

    private void OnClickBtnExit()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        OnBackPressed();
    }

    public override void Show(bool _isShown, bool isHideMain = true)
    {
        base.Show(_isShown, isHideMain);

        if (!isShow)
        {
            return;
        }
    }

    private void CheckOpenEquip()
    {
        if (LobbyManager.Ins.CurrentLevel >= 6)
        {
            OpenEquips[0].gameObject.SetActive(false);
        }
        if(LobbyManager.Ins.CurrentLevel >= 12)
        {
            OpenEquips[1].gameObject.SetActive(false);
            OpenEquips[2].gameObject.SetActive(false);
        }
    }

    private void OnClickBtnEquip0()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.soundEquip);
        LobbyManager.Ins.UIMainLobby.uIAirTitle.ImgAir.sprite = imgAir[0];
        LobbyManager.Ins.UIMainLobby.uIAirTitle.IdAir = 0;
        PlayerPrefs.SetInt(Helper.IDAIR, 0);
    }

    private void OnClickBtnEquip1()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.soundEquip);
        LobbyManager.Ins.UIMainLobby.uIAirTitle.ImgAir.sprite = imgAir[1];
        LobbyManager.Ins.UIMainLobby.uIAirTitle.IdAir = 1;
        PlayerPrefs.SetInt(Helper.IDAIR, 1);
    }

    private void OnClickBtnEquip2()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.soundEquip);
        LobbyManager.Ins.UIMainLobby.uIAirTitle.ImgAir.sprite = imgAir[2];
        LobbyManager.Ins.UIMainLobby.uIAirTitle.IdAir = 2;
        PlayerPrefs.SetInt(Helper.IDAIR, 2);
    }

    private void OnClickBtnEquip3()
    {
        LobbyManager.Ins.UIMainLobby.uIAirTitle.ImgAir.sprite = imgAir[3];
        LobbyManager.Ins.UIMainLobby.uIAirTitle.IdAir = 3;
        PlayerPrefs.SetInt(Helper.IDAIR, 3);
    }
}
