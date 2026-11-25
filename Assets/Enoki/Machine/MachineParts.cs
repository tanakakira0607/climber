using UnityEngine;

public class MachineParts : MonoBehaviour
{
    public int GetNumber()
    {
        return GetComponentInParent<Machine>().MachineNumber;//自分が属するマシンのナンバーを取得する
    }

}
