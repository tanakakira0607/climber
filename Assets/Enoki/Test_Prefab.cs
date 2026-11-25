using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Prefab : MonoBehaviour
{
    [SerializeField] GameObject Pre;

    void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame) Instantiate(Pre, transform.position,Quaternion.Euler(0f, 0f, Random.Range(-70f, 70f)));
    }
}
