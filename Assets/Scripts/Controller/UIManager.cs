using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Title("UI")]
    public UIStartGameLobby uIStartGameLobby;
    public UIMainDecided uIMainDecided;
    public UIWin UiWin;
    public UIGamePlay UiGamePlay;
    public UILose UiLose;

    [Title("Popup")]
    public PopupPause popupPause;
    public PopupExitGame popupExitGame;
    public GameObject popupWarning;
    public GameObject popupWarningBoss;

    [Title("Other")]
    public GameObject Loading;

    [SerializeField]
    private Button txtPlayGame;

    public void Init()
    {
        OpenUiGamePlay();
        uIStartGameLobby.Show(true);
    }

    public void OpenUiGamePlay()
    {
        UiGamePlay.gameObject.SetActive(true);
    }

    public void OpenPopupWarning()
    {
        popupWarning.SetActive(true);
    }

    public void OpenPopupWarningBoss()
    {
        popupWarningBoss.SetActive(true);
    }

    public void DisableAndActiveTxtPlay(bool isActive)
    {
        if (!isActive)
        {
            txtPlayGame.gameObject.SetActive(false);
        }
        else
        {
            txtPlayGame.gameObject.SetActive(true);
        }
    }

    public void OpenUiMainDecide()
    {
        uIMainDecided.Show(true);
    }

    public void OpenUiWin(int gold)
    {
        GameManager.Instance.Profile.AddGold(Constants.GOLD_WIN);
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.win);
        Time.timeScale = 0f;
        UiWin.Show(true);
    }

    public void OpenUiLose()
    {
        GameManager.Instance.Profile.AddGold(Constants.GOLD_LOSE);
        SoundManager.Instance.playSound(SoundManager.Instance.soundData.lose);
        Time.timeScale = 0f;
        UiLose.Show(true);
    }

    public void OpenPopupExitGame()
    {
        popupExitGame.Show(true);
    }

    public void OpenPopupPause()
    {
        popupPause.Show(true);
    }
}
