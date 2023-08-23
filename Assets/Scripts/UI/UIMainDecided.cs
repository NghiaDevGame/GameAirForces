using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainDecided : UICanvas
{

    [Title("Text")]
    [SerializeField] private Button txt1;
    [SerializeField] private Text txtWave;

    [Title("Tween")]
    //private Tween tween;

    private void Start()
    {
        txt1.onClick.AddListener(OnClickBtnNextLevel);
    }

    private void Update()
    {
        txtWave.text = "Wave " + GameManager.Instance.CountDownStage
            + "/" + GameManager.Instance.CountStage;
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
