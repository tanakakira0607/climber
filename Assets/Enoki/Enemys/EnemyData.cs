using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("図鑑番号")]
    public int EnemyID = 1;//図鑑番号
    [Header("図鑑イラスト")]
    public Sprite EnemySprite;
    [Header("初期最大HP")]
    public int MaxHP = 10;
    [Header("命中時のスコア倍率")]
    public float HitScore = 5;
    [Header("撃破時のスコア")]
    public int KillScore = 10;//撃破時のスコア
    [Header("エネミータイプ")]
    public EnemyType Enemy_Type = EnemyType.Normal;


    public int SetDefaultHP(){ return MaxHP; }


}


public enum EnemyType //https://cafecafeoore.com/unity-enum%E5%88%97%E6%8C%99%E5%9E%8B%E3%81%AE%E5%9F%BA%E6%9C%AC%E7%9A%84%E3%81%AA%E4%BD%BF%E3%81%84%E6%96%B9%E3%81%A8%E6%B3%A8%E6%84%8F%E7%82%B9%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6/
{
    Normal = 0,
    Elite = 10,
    Boss = 20,
}
