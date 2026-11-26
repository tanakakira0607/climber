using UnityEngine;
using System.Collections.Generic;
public class Stage : MonoBehaviour // statics = 敵の強化倍率、現在の部屋番号
{
    [SerializeField]GameObject Cam;
    [Header("部屋(マシン)ごとのカメラの位置。部屋の数を取得するのにも使う")]
    [SerializeField] CameraPosesDatabase CameraPositions;
    [Header("現在の部屋番号")]
    public static int RoomNumber = 0;
    [Header("最後の部屋番号。この番号が割り当てられた部屋をクリアするとフロアクリア")]
    public int LastStageNumber = 0;
    [Header("部屋ごとの獲得スコア。※長さは部屋の数と同じになるようにしてください")]
    [SerializeField] List<int> Scores;
    [Header("フロア内で獲得した総スコア。表示用")]
    public int FloorScore = 0;
    [Header("フロア内の敵の強化倍率")]
    public static float EnemyPowered = 1;

    CameraController CC;

    private void Start(){
        RoomNumber = 0;
        Cam = GameObject.Find("Main Camera");
        CC = Cam.GetComponent<CameraController>();
        CC.MoveCamera(CameraPositions.CameraPos_Datas[0].CameraPosiotion);//0には最初のカメラの位置データを入れておく
        LastStageNumber = Scores.Count;
        PlayerStatus.ApplyDefaultStatus();
    }
    public int SumFloorScore() {
        int Sum = 0;
        foreach (int i in Scores) Sum += i;
        FloorScore = Sum;//表示用
        return Sum;
    }
    public void StageChange(int NextStageNumber){
        Scores[RoomNumber] = PlayerStatus.Score;
        PlayerStatus.ScoreReset();
        RoomNumber = NextStageNumber;
        CC.MoveCamera(CameraPositions.CameraPos_Datas[NextStageNumber].CameraPosiotion);
    }
    //public void StageFinished()
    //{
    //    Scores[RoomNumber] = PlayerState.Score;
    //    FloorScore += PlayerState.Score;
    //    PlayerState.Score = 0;
    //}
}
