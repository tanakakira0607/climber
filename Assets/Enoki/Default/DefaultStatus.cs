using UnityEngine;

public class DefaultStatus : MonoBehaviour//プレイヤーの初期ステータス等
{
    [Header("数値はレベルを表すものとする")]
    public static int LifeLv = 0;
    public static int ATKLv = 0;
    public static int ScoreBoostLv = 0;
    public static int XPBoostLv = 0;
    public static int OverScoreBoostLv = 0;

    [Header("以下、表示用")]
    [Header("初期ステータス強化レベル")]
    [SerializeField] int LifeLevel = 0;
    [SerializeField] int ATKLevel = 0;
    [SerializeField] int Score_BoostLevel = 0;
    [SerializeField] int XP_BoostLevel = 0;
    [SerializeField] int OverScoreLossCut_Level = 0;
    private void Update()
    {
        LifeLevel = LifeLv;
        ATKLevel = ATKLv;
        Score_BoostLevel = ScoreBoostLv;
        XP_BoostLevel = XPBoostLv;
        OverScoreLossCut_Level =OverScoreBoostLv ;
    }
}
