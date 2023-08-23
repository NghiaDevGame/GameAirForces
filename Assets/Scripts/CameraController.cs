using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private new Camera camera;
    [SerializeField] private AudioListener audioListener;

    public Camera Camera => camera;
    public AudioListener AudioListener => audioListener;
}
