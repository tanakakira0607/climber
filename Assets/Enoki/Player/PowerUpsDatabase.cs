using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpsDatabase", menuName = "Scriptable Objects/PowerUpsDatabase")]
public class PowerUpsDatabase : ScriptableObject
{
    [SerializeField] public List<PowerUpCard> PowerUp_Datas = new List<PowerUpCard>();
}
