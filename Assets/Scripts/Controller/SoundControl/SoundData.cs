using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData : MonoBehaviour
{
    public AudioClip AudiosLobby;
    public AudioClip[] bgMusics;
    public AudioClip soundBuy;
    public AudioClip soundEquip;
    public AudioClip soundUpgrade;
    public AudioClip soundSuccessVideo;

    [Title("Collectibles")]
    public List<AudioClip> ListAudioCollects;

    [Title("Special Objects")]
    public AudioClip[] BreakableObjectSounds;
    public AudioClip HitBedSound;

    [Header("Game Sounds and Musics: ")]
    public AudioClip win;
    public AudioClip lose;
    public AudioClip weapon;
    public AudioClip bossDie;
    public AudioClip trainRunning;
    public AudioClip coin;
    public AudioClip hitbodyEnemy;
    public AudioClip startEnemy;
}
