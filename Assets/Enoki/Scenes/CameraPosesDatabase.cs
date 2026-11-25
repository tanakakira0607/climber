using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraPosesDatabase", menuName = "Scriptable Objects/CameraPosesDatabase")]
public class CameraPosesDatabase : ScriptableObject
{
    [Header("フロア内の部屋のカメラ位置")]
   [SerializeField] public List<CameraPositionData> CameraPos_Datas=new List<CameraPositionData>();
}
