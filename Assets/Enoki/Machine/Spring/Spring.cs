using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Spring : MachineParts
{
    [SerializeField]SliderJoint2D SJ;
    Vector3 MyPosition;
    bool Hold = false;
    float DefaultLowerLimit = 20;
    [SerializeField] float DefaultForce = 80000;
    float Charge = 0;
    [SerializeField] float SpringDownValue = 0.2f;
    //[SerializeField] int SpringPowerValue = ;
    JointTranslationLimits2D limits;
    JointMotor2D Motor;
    void Start()
    {   
        SJ = GetComponent<SliderJoint2D>();
        limits = SJ.limits;
        Motor = SJ.motor;
        DefaultForce = Motor.maxMotorTorque;
        MyPosition = transform.localPosition;
        DefaultLowerLimit = limits.min;
        
        
    }
    //AI
    //「直接代入はエラーになる
    //  sliderJoint.limits.max = 2.0f; のように直接値を書き換えると、C#の構造体の仕様によりコンパイルエラーが発生します。
    //  必ず一度ローカル変数（上記コードの limits）に格納してから書き換えてください。」
   // Sanu
   // 「 Why ??? 」


    void FixedUpdate()
    {
        SJ.useMotor = false;
        if (GetNumber() != Stage.RoomNumber) return;
        if (!Input.Space && Hold) {
            Motor.maxMotorTorque = (DefaultForce*0.15f) + (DefaultForce*Charge*0.85f); SJ.motor = Motor;
            limits.min = DefaultLowerLimit;
            SJ.useMotor = true;
            Hold = false;
            Charge = 0;
        }else if (Input.Space) { 
            Charge += 0.04f; if (Charge > 1) Charge = 1;
            Hold = true;
            limits.min = DefaultLowerLimit - SpringDownValue * Charge;
           
        }
        SJ.limits = limits;//一度別の変数として取り出し、本体へ帰す処理が必要
    }
}
