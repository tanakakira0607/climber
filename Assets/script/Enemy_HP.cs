using UnityEngine;

public class Enemy_HP : MonoBehaviour
{
    [Header("HP")]
    public int enemy_HP;
    [Header("Score")]
    public int points;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    
    void damage(int damage)
    {
        enemy_HP -= damage;
        if (enemy_HP > 0)
        {

            Destroy(gameObject);
            ScoreManeger.Instance.score(points);
        }

    }
}
