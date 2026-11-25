using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataBase", menuName = "Scriptable Objects/EnemyDataBase")]
public class EnemyDataBase : ScriptableObject
{
    [Header("エネミーのデータベース。エネミー一覧")]
    [SerializeField] public List<GameObject> EnemyDatas = new List<GameObject>();
}