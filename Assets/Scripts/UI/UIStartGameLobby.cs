using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStartGameLobby : UICanvas
{

    [Title("Button")] [SerializeField] private Button btnHide;

    public GameObject uiMainLobby;

    // Start is called before the first frame update
    void Start()
    {
        btnHide.onClick.AddListener(OnClickBtnPlay);
        //Init();
    }

    private void OnClickBtnPlay()
    {
        GameManager.Instance.StartLevel();
        ShowAniHide();
    }

    public void ShowAniHide()
    {
        Show(false);
    }

    private void Init()
    {
        //var dataLevel = GameManager.Instance.DataLevel;
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
}
