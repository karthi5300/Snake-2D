using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Animator animator;


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
        score += value;
        if (score > highScore)
        {
            highScore = score;
            animator.SetTrigger("isHigh");
        }
        RefreshUI();
    }

    public void DecreaseScore(int value)
    {
        score -= value;
    }

    public void RefreshUI()
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "Highest Score: " + highScore;
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }
}
