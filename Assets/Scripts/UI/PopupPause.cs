using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPause : UICanvas
{

    [Title("Text")]
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnResume;

    [Title("Tween")]
    //private Tween tween;

    private void Start()
    {
        btnExit.onClick.AddListener(OnClickBtnExit);
        btnResume.onClick.AddListener(OnClickBtnResume);
    }

    private void OnClickBtnResume()
    {
        OnBackPressed();
        GameManager.Instance.Resume();
    }

    private void OnClickBtnExit()
    {
        OnBackPressed();
        GameManager.Instance.UiManager.OpenPopupExitGame();
    }

    public override void Show(bool _isShown, bool isHideMain = true)
    {
        base.Show(_isShown, isHideMain);

        if (!isShow)
        {
            return;
        }
    }

    private void OnNextLevel()
    {
        if (!isShow)
            return;

        StartCoroutine(IEWaitNextLevel());

    }

    private IEnumerator IEWaitNextLevel()
    {
        yield return new WaitForSeconds(0.2f);
        OnBackPressed();
        GameManager.Instance.NextLevel();
    }
}
