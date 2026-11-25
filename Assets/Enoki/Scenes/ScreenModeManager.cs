using UnityEngine;

public class ScreenModeManager : MonoBehaviour
{
    public static Mode mode;
    [Header("以下、インスペクターでの表示用")]
    [SerializeField] Mode Mode_Now;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mode_Now = mode;
    }
}

public enum Mode
{
    Title=0,
    StageSelect=10,
    Game=20,
    Pause=30,
    Skill=40,
    Result=50,
}
