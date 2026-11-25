using UnityEngine;

[CreateAssetMenu(fileName = "2_ScoreUp", menuName = "PowerUpItems/2_ScoreUp")]
public class ScoreUp : PowerUpCard
{
    public override void Status(int Level)
    {
        float ScoreBoostUpValue = 0;
        if (Level <= 8) ScoreBoostUpValue = 0.25f * Level;
        else if(Level >= 9)ScoreBoostUpValue = Level - 5;

        PlayerStatus.ScoreBoost = ScoreBoostUpValue;
    }
}
