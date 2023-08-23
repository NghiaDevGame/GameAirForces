using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCtrl : MonoBehaviour
{
    private static AirCtrl instance;

    private Vector2 defference = Vector2.zero;
    private Camera mainCam;

    [SerializeField]
    private GameObject defense;
    [SerializeField]
    private List<GameObject> skill;
    [SerializeField]
    private List<GameObject> shootings;
    [SerializeField]
    protected int id;

    [SerializeField]
    protected GameObject bulletPrefab;
    [SerializeField]
    protected float force;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected DataAirSO data;
    [SerializeField]
    protected PlayerState state;
    [SerializeField]
    private float countDown = 3;
    private float curCountDown;

    public GameObject Defense { get => defense; set => defense = value; }
    public List<GameObject> Skill { get => skill; set => skill = value; }
    public static AirCtrl Instance { get => instance; set => instance = value; }
    public float Damage { get => damage; set => damage = value; }

    private int indexShoot = 0;
    private int curIndexShoot = 0;

    private void Awake()
    {
        mainCam = Camera.main;
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        curCountDown = countDown;
        damage = data.GetAirByID(id).damage;
        bulletPrefab = data.GetAirByID(id).bullet;
    }

    private void Update()
    {
        Movement();
        OpenSkill();
        DisableSkill();
    }

    private void Movement()
    {
        transform.position = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition) - defference;
    }

    private void DisableSkill()
    {
        if(curCountDown <= 0f)
        {
            if(defense.activeInHierarchy == true)
            {
                defense.SetActive(false);
                curCountDown = countDown;
            }
            if (skill[0].activeInHierarchy == true || skill[1].activeInHierarchy == true)
            {
                skill[0].SetActive(false);
                skill[1].SetActive(false);
                curCountDown = countDown;
            }
        } else
        {
            curCountDown -= Time.deltaTime;
        }
    }

    private void OpenSkill()
    {
        if (Input.GetKey(KeyCode.R))
        {
            skill[0].SetActive(true);
            skill[1].SetActive(true);
            GameManager.Instance.UiManager.UiGamePlay.ImgLock1.fillAmount = 1;
        }
        else if (Input.GetKey(KeyCode.T))
        {
            defense.SetActive(true);
            GameManager.Instance.UiManager.UiGamePlay.ImgLock2.fillAmount = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ItemGun"))
        {
            Destroy(collision.gameObject);
            shootings[curIndexShoot].SetActive(false);
            indexShoot++;
            shootings[indexShoot].SetActive(true);
            curIndexShoot = indexShoot;
        }
    }
}
