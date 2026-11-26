using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PinballBall2D : MonoBehaviour
{
    [Header("速度")]
    public float maxSpeed = 25f;   // 速度の上限(すり抜けや暴走防止)

    [Header("物理設定(自動適用)")]
    public float mass = 1f;
    public float gravityScale = 1.5f;      // 盤面の傾き具合。大きいほど速く落ちる
    public float linearDamping = 0.05f;    // 空気抵抗。小さいほど転がり続ける
    public float angularDamping = 0.1f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.mass = mass;
        rb.gravityScale = gravityScale;
        rb.linearDamping = linearDamping;     // Unity 2022以前は rb.drag
        rb.angularDamping = angularDamping;   // Unity 2022以前は rb.angularDrag
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep; // 止まっても眠らせない
    }

    void FixedUpdate()
    {
        // 速度制限
        if (rb.linearVelocity.magnitude > maxSpeed)   // Unity 2022以前は rb.velocity
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}