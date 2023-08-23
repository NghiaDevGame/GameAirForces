using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettings : UICanvas
{

    [Title("Button")] [SerializeField] private Button btnHide;
    [SerializeField] private Button btnExit;

    public Button BtnPlay => btnHide;

    // Start is called before the first frame update
    void Start()
    {
        btnExit.onClick.AddListener(OnClickBtnExit);
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
