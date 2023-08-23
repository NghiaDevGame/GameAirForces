using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [Title("Sound Data")]
    [SerializeField] public SoundData soundData;

    [Header("Main Settings: ")]
    [Range(0, 1)]
    public float musicVolume;
    [Range(0, 1)]
    public float sfxVolume;

    public AudioSource musicSource;
    public AudioSource sfxSourse;

    [Header("Slider Music and SFX: ")]
    public Slider sliderMusic;
    public Slider sliderSfx;

    public float volumeM;
    public float volumeS;

    public void Start()
    {
        if (sliderMusic != null && sliderSfx != null)
        {
            sliderMusic.maxValue = musicVolume;
            sliderSfx.maxValue = sfxVolume;
            sliderMusic.value = musicVolume;
            sliderSfx.value = sfxVolume;
        }
        playMusic(soundData.bgMusics);
    }

    private void Update()
    {
        if (volumeM == 0 && volumeS == 0)
        {
            volumeM = PlayerPrefs.GetFloat("VolumeMusic");
            volumeS = PlayerPrefs.GetFloat("VolumeSFX");
        }
        musicVolume = volumeM;
        sfxVolume = volumeS;
        musicSource.volume = musicVolume;
    }

    public void SetVolumeMusic(float sliderVoulume)
    {
        volumeM = sliderVoulume;
        PlayerPrefs.SetFloat("VolumeMusic", volumeM);
    }

    public void SetVolumeSFX(float sliderVoulume)
    {
        volumeS = sliderVoulume;
        PlayerPrefs.SetFloat("VolumeSFX", volumeS);
    }

    public void playSound(AudioClip sound, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxSourse;
        }

        if (aus)
        {
            aus.PlayOneShot(sound, sfxVolume);
        }
    }

    public void playSound(AudioClip[] sounds, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxSourse;
        }

        if (aus)
        {
            int random = Random.Range(0, sounds.Length);

            if (sounds[random] != null)
            {
                aus.PlayOneShot(sounds[random], sfxVolume);
            }
        }
    }

    public void playMusic(AudioClip music, bool loop = true)
    {
        if (musicSource)
        {
            musicSource.clip = music;
            musicSource.loop = loop;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
    }

    public void playMusic(AudioClip[] musics, bool loop = true)
    {
        if (musicSource)
        {
            int random = Random.Range(0, musics.Length);

            if (musics[random] != null)
            {
                musicSource.clip = musics[random];
                musicSource.loop = loop;
                musicSource.volume = musicVolume;
                musicSource.Play();
            }
        }
    }

}
