using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;

    private float currentScore = 0f;
    private bool isPlaying = false;

    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        scoreText.text = "Score: " + PrettyScore();
    }

    private void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
            UpdateScoreText();
            Debug.Log("Score: " + PrettyScore());
        }
    }

    public void StartGame()
    {
        onPlay.Invoke();
        isPlaying = true;
    }

    public void GameOver()
    {
        onGameOver.Invoke();
        currentScore = 0;
        isPlaying = false;
        UpdateScoreText();
    }

    public string PrettyScore()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public void AddScore(float points)
    {
        currentScore += points;
    }

    public void CollectCoin()
    {
        AddScore(10);
        Debug.Log("Coin collected. Current Score: " + PrettyScore());
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + PrettyScore();
    }
}
