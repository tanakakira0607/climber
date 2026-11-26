using UnityEngine;

public class ScoreManeger : MonoBehaviour
{

    public static ScoreManeger Instance { get; private set; }
    public int Score { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void score(int point)
    {

        Score += point;
    
    }
 
}
