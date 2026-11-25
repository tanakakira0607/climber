using UnityEngine;

public class OutHole : MachineParts
{
    [SerializeField] GameObject Spawner;
    private void OnCollisionEnter2D(Collision2D col)
    {   
        GameObject Hit = col.gameObject;

        if (Hit.tag != "Player" && Hit.tag != "PlayerSub") return;

        if (Hit.tag == "Player")//落下時、残りライフの数を減らして移動
            PlayerStatus.LifeDown();
        Hit.layer = LayerMask.NameToLayer("Back_Ball");
        Hit.transform.position = Spawner.transform.position;               
    }
}
