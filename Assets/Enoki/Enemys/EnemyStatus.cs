using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]EnemyData ED;

    public int HP=1;
    private void Awake()
    {
        GetDefaultStatus();
    }
    public void GetDefaultStatus()
    {
        HP = (int)(ED.SetDefaultHP() * Stage.EnemyPowered);
    }
    void Death()//オーバーライド用。このまま使う場合は消滅するのみである
    {
        Destroy(gameObject);
    }
    
    public void GetDamage(int Damage)
    {
        if (HP <= 0) return;//撃破演出中の攻撃ヒット対策(撃破してもしばらく当たり判定を残しながら留まるエネミー用)
        int DamagedHP = HP - Damage;
        if (DamagedHP <= 0)
        {
            PlayerStatus.GetScore((int)(ED.HitScore * GetKillScore(Damage)));
            HP = 0;
            Death();
        }
        else
        {
            PlayerStatus.GetScore((int)(ED.HitScore * Damage));//ED.HitScoreはエネミーを攻撃したときに得られるスコアの倍率
            HP -= Damage;
        }
    }

    int GetKillScore(int Damage)//撃破時のスコア計算。エネミーのキルスコアと残り HP 分に超過した分のダメージを足したスコアを獲得する
    {
        int OverDamageValue = Damage - HP;

        return ED.KillScore + (HP + (int)(OverDamageValue * PlayerStatus.OverScoreLoss));
        
    }
}
