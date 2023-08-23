using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DataAirEnemy", menuName = "ScriptableObjects/Data Air Enemy", order = 1)]
public class DataAirEnemySO : SerializedScriptableObject
{
    [SerializeField]
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MaxScrollViewHeight = 400, MinScrollViewHeight = 200)]
    public List<DataAirEnemy> dataAirEnemies = new List<DataAirEnemy>();

    public DataAirEnemy GetEnemyByID(int id)
    {
        return dataAirEnemies.FirstOrDefault((e) => e.id == id);
    }
}

/// <summary>
/// Dữ liệu cho một air enemy trong data
/// </summary>
public class DataAirEnemy
{
    public int id;
    public float damage;
    public float maxHealth;
    public GameObject bullet;
    public GameObject dragItem;
}
