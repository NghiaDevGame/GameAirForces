using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [Title("Information")]
    [SerializeField] private float timeDelay;
    [SerializeField] private int countSpawn;
    public float timeCurDelay;
    private int count = 0;
    [SerializeField] private List<Transform> posSpawn;

    [Title("Enemy Object")]
    [SerializeField] private GameObject enemy;
    private int indexPos;

    private void Awake()
    {
        GameManager.Instance.CountEnemy = countSpawn;
    }

    protected void Start()
    {
        timeCurDelay = timeDelay;
    }

    private void Update()
    {
        SpawnEnemyGame();
    }

    private void SpawnEnemyGame()
    {
        if (count == countSpawn) return;
        timeCurDelay -= Time.deltaTime;
        if (timeCurDelay <= 0f)
        {
            indexPos = Random.Range(0, posSpawn.Count);
            Instantiate(enemy, posSpawn[indexPos].position, Quaternion.identity);
            count++;
            timeCurDelay = timeDelay;
        }
        else
        {
            timeCurDelay -= Time.deltaTime;
        }
    }

    public void DelayedDestroyLevel(float delayTime = 0.2f)
    {
        StartCoroutine(DelayedEndgameCoroutine(delayTime));
    }

    private IEnumerator DelayedEndgameCoroutine(float delayTime)
    {
        yield return Yielders.Get(delayTime);
        if (gameObject.activeInHierarchy == true)
        {
            Destroy(gameObject);
        }
    }

}
