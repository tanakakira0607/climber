using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class PlayerStatus : MonoBehaviour//デフォルトステータス、フロア内で獲得したパワーアップなどを適用する
{
    static GameObject PS;

    public static int Life = 1;//残りボールの数。残機
    public static int ATK;//攻撃力

    public static int XP;//収集した経験値
    public static float XPBoost = 1;//経験値獲得倍率
    public static int PlayerLevel = 1;//レベル

    public static int Score = 0;//獲得スコア
    public static float ScoreBoost = 1;//スコア獲得倍率
    public static float OverScoreLoss = 1;//敵をオーバーキルした場合、超過した分のダメージによるスコアが減少する。(EnemyStatus.GetDamageを参照)

    public static List<PowerUpCard> GotPowerUps = new List<PowerUpCard>();

    public static GameObject PlayerEffect;
    [Header("以下、表示用")]
    [Header("プレイヤーのパラメータ")]

    //ヒエラルキーで表示用
    [SerializeField] int Left_Life = 0;
    [SerializeField] int Attack_Power = 0;
    [SerializeField] int Collected_XP = 0;
    [SerializeField] float XP_Boost = 0;
    [SerializeField] int Player_Level = 0;
    [SerializeField] int Got_Score = 0;
    [SerializeField] float Score_Boost = 0;
    [SerializeField] float Over_Score_Loss = 0;
    [SerializeField] List<PowerUpCard> Got_Power_Ups = new List<PowerUpCard>();//獲得履歴としても利用可能

    private void Update()
    {
        Left_Life = Life;
        Attack_Power = ATK;
        Collected_XP = XP;
        XP_Boost = XPBoost;
        Player_Level = PlayerLevel;
        Got_Score = Score;
        Score_Boost = ScoreBoost;
        Over_Score_Loss = OverScoreLoss;
        Got_Power_Ups = GotPowerUps;
    }
    public static void ApplyDefaultStatus()

    {
        Life = 3 + DefaultStatus.LifeLv;
        ATK = 10 + DefaultStatus.ATKLv * 2;
        XPBoost = 1 + DefaultStatus.XPBoostLv * 0.4f;
        ScoreBoost = 1 + DefaultStatus.ScoreBoostLv * 0.05f;
        OverScoreLoss = 1 - DefaultStatus.OverScoreBoostLv * 0.1f;

        //プレイヤー初期レベル分だけレベルアップ
        Debug.Log("初期ステータス適用完了");
    }

    //public static List<PowerUpCard> GetPowerUps()


    //public static void StatusChangeTrigger(){ PS.GetComponent<PlayerStatus>().StatusChange(); }
    public static void StatusChange() {//ステータス更新の処理 
        if(PlayerEffect==null)PlayerEffect = GameObject.Find("PlayerEffects");

        ApplyDefaultStatus();

        List<PowerUpCard> Counted_PowerUps_=new List<PowerUpCard>();//ステータス基礎値上昇系パワーアップを適用する一連の処理
        foreach (PowerUpCard PUC in GotPowerUps)//種類を記録する
        {
            if (!Counted_PowerUps_.Contains(PUC)) Counted_PowerUps_.Add(PUC);
        }
        foreach (PowerUpCard T_PUC in Counted_PowerUps_)//各種類のパワーアップを持ってる数 = レベルで適用する
        {
            int Level = 0;
            foreach (PowerUpCard PUC in GotPowerUps)
            {
                if(PUC==T_PUC)Level++;
            }
            T_PUC.Status(Level);
        }

        foreach (Player_Effect PF in PlayerEffect.GetComponents<Player_Effect>())//各バフやデバフを適用する
        {
            PF.Status();
        }

    }

    public static void ScoreReset()
    {
        Score = 0;
    }
    public static void GetScore(int GetScore)
    {
        Score += (int)(GetScore * ScoreBoost);
    }

    public static void LifeDown()
    {
        Life--;
    }
    public static void GetXP()
    {
        /*
        if(XP > "NeedXP") {
            XP-=NeedXP;
            LevelUp(0);
        }
        */
    }

    public static void LevelUp(LevelUpType Pattern)//経験値収集以外でレベルが上がるパターンを想定
    {
        PlayerLevel++;
    }

    
}

public enum LevelUpType
{
    XP=0,//経験値によるレベルアップ
    LevelUpper =10//直接レベルを上げるアイテム
}