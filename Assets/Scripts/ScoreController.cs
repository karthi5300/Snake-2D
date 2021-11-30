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

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int value)
    {
        score += value * scoreMultiplier;
        if (score > highScore)
        {
            highScore = score;
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
        highScoreText.text = "Highest Score: " + highScore;
        finalScoreText.text = "Score: " + score; ;
        finalHighScoreText.text = "Highest Score: " + highScore;
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
