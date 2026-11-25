using UnityEngine;

public class Player_Effect : Effect_Base
{
    [SerializeField] bool IsStatusEffect;
    private void Start()
    {
        if(IsStatusEffect) PlayerStatus.StatusChange();
    }
    public virtual void Status() { }//ƒXƒe[ƒ^ƒX•Ï‰»Œn

    public virtual void Attack() { }//UŒ‚–½’†

    public virtual void GetAttack() { }//ƒ{[ƒ‹‚ª“G‚ÌUŒ‚”»’è‚ÉG‚ê‚½

    public override void TimeUpEffect()
    {
        if (IsStatusEffect) PlayerStatus.StatusChange();
        base.TimeUpEffect();
    }
}