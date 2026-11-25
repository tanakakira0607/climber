using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("以下、インスペクターでの表示用")]
    [Header("入力情報")]
    [SerializeField] bool Right = false;
    [SerializeField] bool Left = false;
    [SerializeField] bool Space = false;
    void Update()
    {
        Right = Space;Space = Left;Left = Right;//コンソールで Never usedを表示させないようにしているだけなのでお気になさらず

        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.fKey.isPressed || Mouse.current.leftButton.isPressed) { Input.LF = true; Left = true; }
        else { Input.LF = false; Left = false; }
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.jKey.isPressed || Mouse.current.rightButton.isPressed) { Input.RF = true; Right = true; }
        else { Input.RF = false; Right = false; }

        if (Keyboard.current.spaceKey.isPressed) { Input.Space = true; Space = true; }
        else {Input.Space = false; Space = false;}
        //if (Keyboard.current.spaceKey.wasReleasedThisFrame)
    
        
    }
}
