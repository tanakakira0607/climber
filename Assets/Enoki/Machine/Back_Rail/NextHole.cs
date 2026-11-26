using UnityEngine;

public class NextHole : MachineParts
{
    GameObject ForWarpPos;//ボールが向かう座標を取得する
    GameObject ForBallGoPos;//ボールが背景で移動開始する地点
    [SerializeField] int NextNum = 1;
    [SerializeField] Stage ST;
    [SerializeField] float WaitTime=3f;
    private void Start()
    {
        if (ST != null)
        {
            GameObject Manager = GameObject.Find("GameManager");
            ST= Manager.GetComponent<Stage>();
            ForWarpPos = transform.Find("Enter_Pos").gameObject;
            ForBallGoPos = transform.Find("Next_Anchor")?.gameObject ?? transform.Find("End_Anchor").gameObject;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject Hit = col.gameObject;
        if (Hit.tag != "Player") return;
        Hit.GetComponent<Ball>().ChangeTargetPos(ForBallGoPos.transform.position, ForWarpPos.transform.position,WaitTime);//接続点または出口の座標を移動先に設定する
        Hit.layer = LayerMask.NameToLayer("Back_Rail");
        Hit.transform.position = ForWarpPos.transform.position;
        ST.StageChange(NextNum);
        CameraController.CameraSpeed = 0.3f;
    }
}
