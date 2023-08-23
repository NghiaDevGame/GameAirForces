using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILose : UICanvas
{
    [Title("Button")]
    [SerializeField] private Button btnReplay;
    [SerializeField] private Button btnExit;

    [Title("Tween")]
    //private Tween tween;

    private void Start()
    {
        btnReplay.onClick.AddListener(OnClickBtnReplay);
        btnExit.onClick.AddListener(OnClickBtnExit);
    }

    private void OnClickBtnExit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lobby");
        OnBackPressed();
    }

    private void OnClickBtnReplay()
    {
        //OnNextLevel();
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
