using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIMainLobby : UICanvas
{

    [Title("Button")] [SerializeField] private Button btnHide;

    public GameObject uiMainLobby;
    public UILobbyPlay uILobbyPlay;
    public UIUpgrade uIUpgrade;
    public UIEquipAir uIEquipAir;
    public UISettings uISettings;
    public UIDescription uIDescription;
    public UIAirTitle uIAirTitle;

    public GameObject uiSuccess;
    public Image fill;

    public void ShowAniHide()
    {
        Show(false);
    }

    private void Init()
    {
        uiMainLobby.SetActive(true);
    }

    public override void Show(bool _isShown, bool isHideMain = true)
    {
        base.Show(_isShown, isHideMain);
        if (IsShow)
        {
            Init();
        }
        else
        {
            uiMainLobby.SetActive(false);
        }
    }

    public void OpenUiAirTitle()
    {
        uIAirTitle.Show(true);
    }

    public void OpenUiSuccess()
    {
        uiSuccess.gameObject.SetActive(true);
    }

    public void OpenUIMap()
    {
        uILobbyPlay.Show(true);
    }

    public void OpenUIUpgrade()
    {
        uIUpgrade.Show(true);
    }

    public void OpenUIDescription()
    {
        uIDescription.Show(true);
    }

    public void OpenUISettings()
    {
        uISettings.Show(true);
    }

    public void OpenUIEquipAir()
    {
        uIEquipAir.Show(true);
    }
}
