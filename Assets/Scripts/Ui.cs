using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    public TMP_Text playText;
    public TMP_Text scoreText;
    public TMP_Text gameOverText;

    void OnEnable()
    {
        GameManager.playerHit += OnPlayerHit;
        GameManager.gameOver += OnGameOver;
        GameManager.enemyKilled += OnEnemyKilled;
    }

    void OnDsiable()
    {
        GameManager.playerHit -= OnPlayerHit;
        GameManager.gameOver -= OnGameOver;
        GameManager.enemyKilled -= OnEnemyKilled;
    }

    private void OnPlayerHit()
    {
        //
    }

    private void OnGameOver()
    {
        StartCoroutine(GameOverBlink());
    }

    private void OnEnemyKilled()
    {
        // Update score text
        scoreText.text = GameManager.score.ToString();
    }


    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        StartCoroutine(StartGameBlink());
    }

    void Update()
    {
        // Start game when pressing left mouse button
        if (GameManager.gameState == GameManager.GameStates.Start && Input.GetMouseButtonDown(0))
        {
            GameManager.StartGame();
            playText.gameObject.SetActive(false);
        }
    }

    IEnumerator StartGameBlink()
    {
        while (GameManager.gameState == GameManager.GameStates.Start)
        {
            playText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.75f);
            playText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.25f);
        }
        yield break;
    }

    IEnumerator GameOverBlink()
    {
        int blikns = 5;
        while (blikns > 0)
        {
            gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(.75f);
            gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(.25f);
            blikns--;
        }
        GameManager.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
