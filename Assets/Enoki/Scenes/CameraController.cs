using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera C;
    Vector2 TargetPos;
    public static bool AutoCameraMode = true;//カメラが揺れる演出など、任意でカメラを動かしたい場合に false にする。演出が終了したら true に戻すこと。
    public static float CameraSpeed = 1.0f;//カメラの移動速度
    float TargetSize = 20;
    public void Start()
    {
        C = GetComponent<Camera>();
    }
    public void MoveCamera(Vector2 GotPos){TargetPos = GotPos;}
    private void FixedUpdate()
    {
        /*
        gameObject.transform.position = TargetPos;// Vector3変数 に Vector2変数 を代入。x と y の変更だけ反映され、z は暗黙的に 0 に設定される
                                                  //代入以外 (足し算などの演算) でこのやり方を使うとエラーになる
        */
        if (!AutoCameraMode) return;
        Vector2 Diff = transform.position - new Vector3(TargetPos.x,TargetPos.y,-10);

        if(Diff.magnitude<0.1f)transform.position = new Vector3(TargetPos.x,TargetPos.y,-10);
        else if (Diff.magnitude <= 5f) transform.position = Vector3.Lerp(transform.position, new Vector3(TargetPos.x,TargetPos.y,-10), Time.fixedDeltaTime * 4f* CameraSpeed);
        else if (Diff.magnitude > 5f || Diff.magnitude <= 8f) transform.position = Vector3.Lerp(transform.position, new Vector3(TargetPos.x, TargetPos.y, -10), Time.fixedDeltaTime * 6f * CameraSpeed);
        else transform.position = Vector3.Lerp(transform.position, new Vector3(TargetPos.x, TargetPos.y, -10), Time.fixedDeltaTime * 8f * CameraSpeed);

        float Size_Diff = C.orthographicSize - TargetSize;
        float ASD = Mathf.Abs(Size_Diff);//Absolute value of the Size Diff
        if (ASD <= 0.05f) C.orthographicSize = TargetSize;
        else if (ASD > 0.05f && ASD <= 4) C.orthographicSize -= Size_Diff * Time.fixedDeltaTime*4 * CameraSpeed;
        else if (ASD > 4 && ASD <= 8) C.orthographicSize -= Size_Diff * Time.fixedDeltaTime * 8 * CameraSpeed;
        else C.orthographicSize -= Size_Diff * Time.fixedDeltaTime * 16 * CameraSpeed;


    }
}
