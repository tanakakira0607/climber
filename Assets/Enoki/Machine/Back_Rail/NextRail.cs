using UnityEngine;
using System.Collections;
public class NextRail : MachineParts
{
    [SerializeField] float Delay=3;
    GameObject ForBallGoPos;
    [SerializeField] float WaitTime = 3f;

    void OnTriggerEnter2D(Collider2D col)
    {
        ForBallGoPos = transform.Find("Next_Anchor")?.gameObject ?? transform.Find("End_Anchor").gameObject;//Ç«ÇøÇÁÇ©ï–ï˚Ç™ë∂ç›Ç∑ÇÈÇ±Ç∆ÇëOíÒÇ∆Ç∑ÇÈ
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