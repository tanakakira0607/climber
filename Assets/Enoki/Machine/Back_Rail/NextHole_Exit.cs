using UnityEngine;
using System.Collections;
public class NextHole_Exit : MachineParts
{
    GameObject ForWarpPos;
    Stage ST;
    [SerializeField] Vector2 ShotVector;
    [SerializeField] Machine Machine;
    [SerializeField] float Delay;
    private void Start()
    {
        if (ST != null)
        {
            GameObject Manager = GameObject.Find("GameManager");
            ST= Manager.GetComponent<Stage>();
        }
        ForWarpPos = transform.Find("Exit_WarpPos").gameObject;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject Hit = col.gameObject;
        if (Hit.tag != "Player") return;
        Hit.GetComponent<Ball>().arrival(gameObject.transform.position);
        StartCoroutine(DelayShot(Hit));
        
    }
    IEnumerator DelayShot(GameObject Hit)
    {
        yield return new WaitForSeconds(Delay);
        Hit.layer = LayerMask.NameToLayer("Front");
        Hit.transform.position = ForWarpPos.transform.position;
        Hit.GetComponent<Rigidbody2D>().linearVelocity = ShotVector;
        CameraController.CameraSpeed = 1;
        yield return new WaitForSeconds(0.6f);
        Machine.CloseNextGate();
    }
}