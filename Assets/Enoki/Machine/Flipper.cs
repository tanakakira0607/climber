using UnityEngine;
using UnityEngine.InputSystem;
public class Flipper : MachineParts
{
    HingeJoint2D MyHJ2;
    [Header("右側のフリッパーか")]
    [SerializeField] bool Right;
    [SerializeField] Sprite DefaultFlipper;
    [SerializeField] Sprite BrokenFlipper;
    int defaultFliperHP = 100;
    public int FlipperHP = 100;
    float breakTime = 0;
    [SerializeField] BoxCollider2D bc;
    private void Start()
    {
        FlipperHP = GetHP(1);
        MyHJ2 = GetComponent<HingeJoint2D>();
        bc = GetComponent<BoxCollider2D>();
    }
    int GetHP(int n) { return defaultFliperHP / n; }
    void FixedUpdate()
    {
        if (FlipperHP < 0) { FlipperHP = 0; FlipperBroak(); }
        if (FlipperHP == 0)
        {
            breakTime += Time.fixedDeltaTime;
            bc.enabled = false;
        }
        else
        {
            breakTime = 0; bc.enabled = true;



            if (GetNumber() == Stage.RoomNumber)
            {
                if (Right) MyHJ2.useMotor = Input.RF;
                else MyHJ2.useMotor = Input.LF;
            }
            else MyHJ2.useMotor = false;
        }
        if (breakTime > 5)
        {
            FlipperHP = GetHP(2);
            FlipperRepaired();
        }

        Flipper_Effect[] GetEffects()
        {
            Flipper_Effect[] Has_Effects = GetComponents<Flipper_Effect>();

            return Has_Effects;
        }

        void FlipperRepaired()//修復時、トリガーとなるエフェクトを適用する
        {
            foreach (var effect in GetEffects())
            {
                effect.RepairedFlipper();
            }
        }

        void FlipperBroak()//フリッパー破壊時
        {
            foreach (var effect in GetEffects())
            {
                effect.BreakFlipper();
            }
        }


    }
}