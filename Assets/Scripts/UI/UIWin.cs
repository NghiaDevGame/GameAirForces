using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIWin : UICanvas
{

    [Title("Text")]
    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnExit;

    [Title("Tween")]
    //private Tween tween;

    private void Start()
    {
        btnNext.onClick.AddListener(OnClickBtnNextLevel);
        btnExit.onClick.AddListener(OnClickBtnExit);
    }

    private void OnClickBtnExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby");
        OnBackPressed();
    }

    private void OnClickBtnNextLevel()
    {
        OnNextLevel();
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
