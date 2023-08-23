using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DataAir", menuName = "ScriptableObjects/Data Air", order = 1)]
public class DataAirSO : SerializedScriptableObject
{
    [SerializeField]
    [TableList(ShowIndexLabels = true, DrawScrollView = true, MaxScrollViewHeight = 400, MinScrollViewHeight = 200)]
    public List<DataAir> dataAir = new List<DataAir>();

    public DataAir GetAirByID(int id)
    {
        return dataAir.FirstOrDefault((e) => e.id == id);
    }

    public void SetDataAir0(int id, float _damage)
    {
        dataAir[id].damage += _damage;
    }

    public void SetDataAir1(int id, int health)
    {
        dataAir[id].maxHealth += health;
    }
}

/// <summary>
/// Dữ liệu cho một air trong data
/// </summary>
public class DataAir
{
    public int id;
    public float damage;
    public float maxHealth;
    public GameObject bullet;
}
