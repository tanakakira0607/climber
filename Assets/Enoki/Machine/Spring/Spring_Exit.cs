using UnityEngine;

public class Spring_Exit : MachineParts
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Hit = collision.gameObject;
        if (!(Hit.tag == "Player"||Hit.tag=="PlayerSub")) return;
        Hit.layer = LayerMask.NameToLayer("Front"); 
    }
}
