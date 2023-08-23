using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathExample2 : MonoBehaviour
{

    public GameObject m_PlayerObj;
    public Transform[] positionPoint;
    [Range(0, 1)]
    public float value;
    // Start is called before the first frame update

    float tempTime;
    // Update is called once per frame
    void Update()
    {
        if (value < 1)
        {
            value += Time.deltaTime / 4;
        }
        iTween.PutOnPath(m_PlayerObj, positionPoint, value);
    }
    private void OnDrawGizmos()
    {

        iTween.DrawPath(positionPoint, Color.green);
    }
}
