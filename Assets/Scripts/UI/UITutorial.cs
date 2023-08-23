using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UITutorial : MonoBehaviour
{

    public GameObject video;
    public VideoPlayer videoPlayer;
    private bool hasPlayed = false;
    public GameObject loading;

    private void Start()
    {
        LoadTutorialGame();
        videoPlayer.loopPointReached += VideoFinished;
    }

    private void VideoFinished(VideoPlayer vp)
    {
        if (!hasPlayed)
        {
            video.SetActive(false);
            loading.SetActive(true);
            hasPlayed = true;
        }
    }

    private void LoadTutorialGame()
    {
        StartCoroutine(LoaddingGame());
    }

    IEnumerator LoaddingGame()
    {
        yield return new WaitForSeconds(2f);
        video.gameObject.SetActive(true);
    }
}
