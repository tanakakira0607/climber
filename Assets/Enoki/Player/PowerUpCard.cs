using UnityEngine;

[CreateAssetMenu(fileName = "PowerUps", menuName = "Scriptable Objects/PowerUps")]
public class PowerUpCard : ScriptableObject
{
    public string PowerUp_Name;
    public string PowerUp_Info;
    public int PowerUp_ID;
    public PowerUpType PowerUp_Type;
    public int MaxLevel;

    //オーバーライド用
    public virtual void MachineStart(int Level) { }//部屋開始時

    public virtual void MachineEnd(int Level) { }//部屋クリア時

    public virtual void HitBall(int Level) { }//攻撃命中時

    public virtual void FlipperBreak(int Level) { }//フリッパーが破壊されたとき

    public virtual void Status(int Level) { }//ステータス上昇系

    public virtual void TimeTrigger(int Level, float Time) { }//時間経過で発動系
}

public enum PowerUpType//https://cafecafeoore.com/unity-enum%E5%88%97%E6%8C%99%E5%9E%8B%E3%81%AE%E5%9F%BA%E6%9C%AC%E7%9A%84%E3%81%AA%E4%BD%BF%E3%81%84%E6%96%B9%E3%81%A8%E6%B3%A8%E6%84%8F%E7%82%B9%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6/
{
    StatusUpper = 0,
    ExtraBall = 10,
    EXTRAWeapon = 20
}