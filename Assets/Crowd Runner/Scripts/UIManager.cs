using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;


    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        progressBar.value = 0;

        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        levelText.text = $"Level {ChunkManager.instance.GetLevel() + 1}";

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.Gameover)
        {
            ShowGameOver();
        }
    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);

        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void UpdateProgressBar()
    {
        if(!GameManager.instance.IsGameState())
        {
            return;
        }

        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }

    public void RetryButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
