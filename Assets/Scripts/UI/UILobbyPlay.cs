using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILobbyPlay : UICanvas
{

    [Title("Button")] [SerializeField] private Button btnHide;
    [SerializeField] private Button btnPlay1;
    [SerializeField] private Button btnPlay2;
    [SerializeField] private Button btnPlay3;
    [SerializeField] private Button btnExit;
    [SerializeField] private List<Image> imgOpen;

    public Button BtnPlay => btnHide;

    // Start is called before the first frame update
    void Start()
    {
        btnPlay1.onClick.AddListener(OnClickBtnPlay);
        btnPlay2.onClick.AddListener(OnClickBtnPlay);
        btnPlay3.onClick.AddListener(OnClickBtnPlay);
        btnExit.onClick.AddListener(OnClickBtnExit);
        CheckOpenMap();
    }

    private void OnClickBtnExit()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        OnBackPressed();
    }

    private void OnClickBtnPlay()
    {
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.HitBedSound);
        SceneManager.LoadScene("GamePlay");
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

    private void CheckOpenMap()
    {
        if (LobbyManager.Ins.CurrentLevel >= 6)
        {
            imgOpen[0].gameObject.SetActive(false);
        }
        if (LobbyManager.Ins.CurrentLevel >= 12)
        {
            imgOpen[1].gameObject.SetActive(false);
        }
    }
}
