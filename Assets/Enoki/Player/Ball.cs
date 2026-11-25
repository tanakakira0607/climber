using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    Vector2 TargetBackPos;
    Vector2 RailStartPos;
    float Wait_Time;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Back_Rail"))
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = (TargetBackPos - RailStartPos) * Time.fixedDeltaTime / Wait_Time * 60f;

        }
        else
        {
            rb.gravityScale = 8f;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)//衝突時、対象が敵ならPlayerStateの値を参照してダメージを与える
    {
        GameObject Target = col.gameObject;
        if (Target.tag != "Enemy") return;
        Target.GetComponent<EnemyStatus>().GetDamage(PlayerStatus.ATK);
    }
    public void ChangeTargetPos(Vector2 targetPos,Vector2 StartPos,float WaitTime)
    {
        transform.position =RailStartPos= StartPos;
        TargetBackPos = targetPos;Wait_Time = WaitTime;
    }
    public void arrival(Vector2 StackPos)
    {
        Wait_Time = 10f;
        gameObject.transform.position = RailStartPos = TargetBackPos = StackPos;

    }
}

