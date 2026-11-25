using UnityEngine;

public class Options : MonoBehaviour
{
    public static int BGM_Volume_Value = 80;
    public static int SE_Volume_Value = 80;


    [Header("以下、インスペクターでの表示用")]
    [SerializeField]int BGM_Volume;
    [SerializeField]int SE_Volume;
    private void Update()
    {
        if (BGM_Volume_Value < 0) BGM_Volume_Value = 0;
        if (BGM_Volume_Value > 100) BGM_Volume_Value = 100;
        if (SE_Volume_Value < 0) SE_Volume_Value = 0;
        if (SE_Volume_Value > 100) SE_Volume_Value = 100;

        BGM_Volume =BGM_Volume_Value;
        SE_Volume=SE_Volume_Value;
    }
}
