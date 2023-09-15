using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public Button exitButton;
    public Button restartButton;

    public Text highScoreText;
    public Text scoreText;

    public Button restartLoseButton;
    public Button menuButton;

    private Board board;

    private void Start()
    {
        board = FindObjectOfType<Board>();

        ButtonFunc();
    }

    private void Update()
    {
        SetTexts();
    }

    private void ButtonFunc()
    {
        if (exitButton != null)
        {
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                board.tilemap.ClearAllTiles();
                board.score = 0;
            });
        }

        if (restartLoseButton != null)
        {
            restartLoseButton.onClick.RemoveAllListeners();
            restartLoseButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
            });
        }

        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(0);
            });
        }
    }

    private void SetTexts()
    {
        scoreText.text = "Score: " + board.score;
        highScoreText.text = "Best: " + PlayerPrefs.GetInt("HighScore");
    }
}
