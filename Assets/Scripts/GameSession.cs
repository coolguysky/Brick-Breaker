using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f,10f)][SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlock = 83;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false); // due to execution order
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    private void Update()
    {
        Time.timeScale = gameSpeed; //static
    }
    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
