using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAirTitle : UICanvas
{

    [Title("Button")]
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnOpenUpgrade;

    [SerializeField]
    private Image imgAir;
    [SerializeField]
    private int idAir;

    public Image ImgAir { get => imgAir; set => imgAir = value; }
    public int IdAir { get => idAir; set => idAir = value; }

    [Title("Tween")]
    //private Tween tween;

    private void Start()
    {
        btnExit.onClick.AddListener(OnClickBtnExit);
        btnOpenUpgrade.onClick.AddListener(OnClickBtnOpenUpgrade);
    }

    private void OnClickBtnOpenUpgrade()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        OnBackPressed();
        LobbyManager.Ins.UIMainLobby.OpenUIUpgrade();
        LobbyManager.Ins.UIMainLobby.uIUpgrade.IdAir = idAir;
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
}
