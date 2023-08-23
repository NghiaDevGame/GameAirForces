using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpgrade : UICanvas
{

    [Title("Button")] [SerializeField] private Button btnHide;
    [SerializeField] private Button btnExit;
    [SerializeField] private List<Button> btnUpgrades;
    [SerializeField]
    private DataAirSO data;
    private int idAir;

    public Button BtnPlay => btnHide;

    public int IdAir { get => idAir; set => idAir = value; }

    // Start is called before the first frame update
    void Start()
    {
        btnExit.onClick.AddListener(OnClickBtnExit);
        btnUpgrades[0].onClick.AddListener(OnClickBtnUpgarde0);
        btnUpgrades[1].onClick.AddListener(OnClickBtnUpgarde1);
        btnUpgrades[2].onClick.AddListener(OnClickBtnUpgarde2);
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

    private void OnClickBtnUpgarde0()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.soundUpgrade);
        LobbyManager.Ins.UIMainLobby.OpenUiSuccess();
        LobbyManager.Ins.DeductGoldGame(100);
        data.SetDataAir1(idAir, 10);
    }

    private void OnClickBtnUpgarde1()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.soundUpgrade);
        LobbyManager.Ins.UIMainLobby.OpenUiSuccess();
        LobbyManager.Ins.DeductGoldGame(100);
        data.SetDataAir0(idAir, 5);
    }

    private void OnClickBtnUpgarde2()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.soundUpgrade);
        LobbyManager.Ins.UIMainLobby.OpenUiSuccess();
        LobbyManager.Ins.DeductGoldGame(100);
    }
}
