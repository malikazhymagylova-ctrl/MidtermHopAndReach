using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int lives = 3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI messageText;

    public Transform frog;
    private Vector3 frogStartPosition;

    public int charges = 1;
    public int maxCharges = 3;
    public GameObject[] chargeIcons;

    public int totalSpots = 5;
    private int filledSpots = 0;
    private bool gameEnded = false;

    public bool IsGameEnded { get { return gameEnded; } }

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    void Start()
    {
        if (frog != null) frogStartPosition = frog.position;
        if (messageText != null) messageText.gameObject.SetActive(false);

        UpdateScoreUI();
        UpdateLivesUI();
        UpdateChargeUI();
    }

    void Update()
    {
        if (gameEnded && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    public void ResetFrog()
    {
        if (gameEnded) return;
        if (frog != null) frog.position = frogStartPosition;
    }

    public void LoseLife()
    {
        if (gameEnded) return;

        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            EndGame("GAME OVER");
        }
        else
        {
            ResetFrog();
        }
    }

    public void SpotFilled()
    {
        filledSpots++;
        if (filledSpots >= totalSpots)
        {
            EndGame("YOU WIN!");
        }
    }

    void EndGame(string message)
    {
        gameEnded = true;

        SoundManager.Instance.StopMusic();
        
        if (message == "YOU WIN!") SoundManager.Instance.PlayWin();
        else SoundManager.Instance.PlayGameOver();

        if (messageText != null)
        {
            messageText.text = "<size=150%>" + message + "</size>\n<size=50%>Score: " + score + "\nPress R to restart</size>";
            messageText.gameObject.SetActive(true);
        }

        if (frog != null)
        {
            foreach (MonoBehaviour script in frog.GetComponents<MonoBehaviour>())
            {
                script.enabled = false;
            }
        }

        Time.timeScale = 0f;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    void UpdateLivesUI()
    {
        if (livesText != null) livesText.text = "Lives: " + lives;
    }

    public bool AddCharge()
    {
        if (charges >= maxCharges) return false;
        charges++;
        UpdateChargeUI();
        return true;
    }

    public bool UseCharge()
    {
        if (charges <= 0) return false;
        charges--;
        UpdateChargeUI();
        return true;
    }

    void UpdateChargeUI()
    {
        for (int i = 0; i < chargeIcons.Length; i++)
        {
            if (chargeIcons[i] != null) chargeIcons[i].SetActive(i < charges);
        }
    }
}