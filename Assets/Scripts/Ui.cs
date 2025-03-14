using TMPro;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public TMP_Text scoreText;
    
    void OnEnable()
    {
        Events.enemyKilled += OnEnemyKilled;
    }

    void OnDsiable()
    {
        Events.enemyKilled -= OnEnemyKilled;
    }


    private void OnEnemyKilled(int score)
    {
        int currentScore = int.Parse(scoreText.text);
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }
}
