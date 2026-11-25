using Unity.VisualScripting;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [Header("自分の部屋(マシン)番号")]
    public int MachineNumber = 0;//
    [SerializeField] GameObject NextStages;
    private void Start()
    {
       
         CloseNextGate();
    }
    public void OpenNextStage()
    {
        NextStages.gameObject.SetActive(true);
    }
    public void CloseNextGate() { NextStages.gameObject.SetActive(false); }

    //以下、オーバーライド用。クリアや失敗条件など...
    public void breakFlipper() { }
    public void GetScore() { }

    public void Time() { }

    public void KillEnemy() { }
}
