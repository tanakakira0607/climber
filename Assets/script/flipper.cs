using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HingeJoint2D))]
public class Flipper2D : MonoBehaviour
{
    [Header("操作キー")]
    public KeyCode key = KeyCode.LeftArrow;

    [Header("角度(度)")]
    public float restAngle = 0f;       // 待機時の角度
    public float pressedAngle = 45f;   // キーを押したときの角度(右フリッパーは負の値)

    [Header("動きの強さ")]
    public float motorSpeed = 1000f;   // 回転速度(大きいほど素早く跳ね上がる)
    public float maxMotorTorque = 10000f; // モーターの最大トルク

    private HingeJoint2D hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint2D>();

        hinge.useLimits = true;
        JointAngleLimits2D limits = hinge.limits;
        limits.min = Mathf.Min(restAngle, pressedAngle);
        limits.max = Mathf.Max(restAngle, pressedAngle);
        hinge.limits = limits;

        hinge.useMotor = true;

        // 衝突の取りこぼし防止
        GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void FixedUpdate()
    {
        // 押している間は pressedAngle 方向へ、離したら restAngle 方向へ回す
        float direction = Mathf.Sign(pressedAngle - restAngle);
        bool pressed = Input.GetKey(key);

        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = pressed ? motorSpeed * direction : -motorSpeed * direction;
        motor.maxMotorTorque = maxMotorTorque;
        hinge.motor = motor;
    }
}