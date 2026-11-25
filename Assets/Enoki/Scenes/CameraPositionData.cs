using UnityEngine;

[CreateAssetMenu(fileName = "CameraPositionData", menuName = "Scriptable Objects/CameraPositionData")]
public class CameraPositionData : ScriptableObject
{
    public Vector2 CameraPosiotion;
    public bool UseDefaultCameraSize = true;
    public float CameraSize = 15;
}
