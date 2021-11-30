using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Animator animator;

    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI finalHighScoreText;

    private int scoreMultiplier = 1;


    private int score = 0;
    private int highScore = 0;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int value)
    {
        score += value * scoreMultiplier;
        highScore = PlayerPrefs.GetInt("HS");
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HS", highScore);
            animator.SetTrigger("isHigh");
        }
        RefreshUI();
    }

    public void DecreaseScore(int value)
    {
        if (score > 0)
            score -= value;

        RefreshUI();
    }

    public void RefreshUI()
    {
        scoreText.text = "Score: " + score;
        finalScoreText.text = "Score: " + score; ;
        highScoreText.text = "Highest Score: " + PlayerPrefs.GetInt("HS"); ;
        finalHighScoreText.text = "Highest Score: " + PlayerPrefs.GetInt("HS"); ;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public void ScoreMultiplier()
    {
        scoreMultiplier = 2;
        Invoke("ResetScoreMultiplier", 10f);
    }

    public void ResetScoreMultiplier()
    {
        scoreMultiplier = 1;
    }
}
