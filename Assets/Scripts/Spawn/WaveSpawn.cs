using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : Singleton<WaveSpawn>
{
    [SerializeField]
    private GameObject itemDrag;
    [SerializeField]
    private List<Transform> pointPos;
    private int count = 1;

    private void Update()
    {
        DelayDropItem();   
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

    private void DelayDropItem()
    {
        int indexPos = Random.Range(0, pointPos.Count);
        if(GameManager.Instance.Count == 6)
        {
            if(count == 1) 
            {
                Instantiate(itemDrag, pointPos[indexPos].position, Quaternion.identity);
                count--;
            }
        }
    }
}
