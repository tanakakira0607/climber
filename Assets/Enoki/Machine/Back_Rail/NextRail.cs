using UnityEngine;
using System.Collections;
public class NextRail : MachineParts
{
    [SerializeField] float Delay=3;
    [SerializeField] GameObject ForBallGoPos;
    [SerializeField] float WaitTime = 3f;

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject Hit = col.gameObject;
        if (Hit.tag != "Player") return;
        Hit.GetComponent<Ball>().arrival(gameObject.transform.position);
        StartCoroutine(DelayGo(Hit));

    }
    IEnumerator DelayGo(GameObject Hit)
    {
        yield return new WaitForSeconds(Delay);
        Hit.transform.position = gameObject.transform.position;
        Hit.GetComponent<Ball>().ChangeTargetPos(ForBallGoPos.transform.position, gameObject.transform.position, WaitTime);
        CameraController.CameraSpeed = 1;
    }
}