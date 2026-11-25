using UnityEngine;

public class NextHole : MachineParts
{
    [SerializeField] GameObject ForWarpPos;
    [SerializeField] GameObject ForBallGoPos;
    [SerializeField] int NextNum = 1;
    [SerializeField] Stage ST;
    [SerializeField] float WaitTime=3f;
    private void Start()
    {
        if (ST != null)
        {
            GameObject Manager = GameObject.Find("GameManager");
            ST= Manager.GetComponent<Stage>();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject Hit = col.gameObject;
        if (Hit.tag != "Player") return;
        Hit.GetComponent<Ball>().ChangeTargetPos(ForBallGoPos.transform.position, ForWarpPos.transform.position,WaitTime);//Ú‘±“_‚Ü‚½‚ÍoŒû‚ÌÀ•W‚ğˆÚ“®æ‚Éİ’è‚·‚é
        Hit.layer = LayerMask.NameToLayer("Back_Rail");
        Hit.transform.position = ForWarpPos.transform.position;
        ST.StageChange(NextNum);
        CameraController.CameraSpeed = 0.3f;
    }
}
