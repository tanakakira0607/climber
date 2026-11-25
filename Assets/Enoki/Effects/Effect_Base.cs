using UnityEngine;

public class Effect_Base : MonoBehaviour//オーバーライド元のクラス
{
    public string effectName;//バフ・デバフの名称

    float Keep_Time;//持続時間
    [SerializeField]bool Has_Duration;//時間経過で消える効果か
    void FixedUpdate()
    {
        Keep_Time -= Time.fixedDeltaTime;
        if (Keep_Time < 0 && Has_Duration) { TimeUpEffect(); }
    }

    public virtual void TimeUpEffect() { LostEffect(); }//効果時間切れになると呼び出される。この部分をオーバーライドして消さずに別の処理を行わせたりすることができる
    public virtual void LostEffect() { Destroy(this); }//自コンポーネントを削除する 


}
