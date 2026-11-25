using UnityEngine;

public class ForDebug : MonoBehaviour//デバッグ用。InspectorでApplyをTrueにすると適用できる
{
    [SerializeField]bool Apply=false;
    [Header("初期ステータスレベル")]
    [SerializeField] int Lifes = 0;
    [SerializeField] int ATK = 0;
    [SerializeField] int XPBoost = 0;
    [SerializeField] int ScoreBoost = 0;

    // Update is called once per frame
    void Update()
    {
        if (Apply)
        {
            DefaultStatus.LifeLv = Lifes;
            DefaultStatus.ATKLv = ATK;
            DefaultStatus.XPBoostLv = XPBoost;
            DefaultStatus.ScoreBoostLv = ScoreBoost;



            Apply = false;//適用完了

        }
    }
}
