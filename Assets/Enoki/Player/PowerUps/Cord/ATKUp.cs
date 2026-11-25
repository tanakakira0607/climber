using UnityEngine;
[CreateAssetMenu(fileName = "0_ATKUp", menuName = "PowerUpItems/0_ATKUp")]
public class ATKUp : PowerUpCard//çUåÇóÕè„è∏ÉXÉLÉã
{
    public override void Status(int Level)
    {
        int ATKUpValue = 0;

        if (Level <= 3) ATKUpValue = Level * 5;
        else if (Level <= 9) ATKUpValue = 15 + Level - 3;
        else if (Level >= 10) ATKUpValue = 25 + Level -10;

        PlayerStatus.ATK += ATKUpValue;
    }
}
