using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private UIPanel mainMenuPanel;
    [SerializeField] private UIPanel pausePanel;
    [SerializeField] private UIPanel settingsPanel;
    [SerializeField] private UIPanel creditsPanel;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button mainMenuSettingsButton;
    [SerializeField] private Button mainMenuCreditsButton;
    [SerializeField] private Button mainMenuExitButton;

    [Header("Pause Menu Buttons")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button pauseSettingsButton;
    [SerializeField] private Button pauseCreditsButton;
    [SerializeField] private Button pauseExitButton;
    [SerializeField] private Button pauseBackButton;

    [Header("Settings Menu Buttons")]
    [SerializeField] private Button settingsBackButton;


    [Header("Credits Menu Buttons")]
    [SerializeField] private Button creditsBackButton;


    private bool isPaused = false;

    private void Awake()
    {
        // El juego arranca pausado
        Time.timeScale = 0f;

        // Main Menu abierto al inicio, el resto oculto
        mainMenuPanel.Open(); 
        pausePanel.Close();
        settingsPanel.Close();
        creditsPanel.Close();

        // Listeners
        playButton.onClick.AddListener(Play);
        mainMenuSettingsButton.onClick.AddListener(OpenSettings);
        mainMenuCreditsButton.onClick.AddListener(OpenCredits);
        mainMenuExitButton.onClick.AddListener(ExitGame);

        continueButton.onClick.AddListener(ResumeGame);
        pauseSettingsButton.onClick.AddListener(OpenSettings);
        pauseCreditsButton.onClick.AddListener(OpenCredits);
        pauseExitButton.onClick.AddListener(ExitGame);
        pauseBackButton.onClick.AddListener(BackToMenu);

        settingsBackButton.onClick.AddListener(CloseSettings);
        creditsBackButton.onClick.AddListener(CloseCredits);
    }

    private void Update()
    {
        bool pausable = !mainMenuPanel.gameObject.activeSelf
                                  && !settingsPanel.gameObject.activeSelf
                                  && !creditsPanel.gameObject.activeSelf;

        if (Input.GetKeyDown(KeyCode.Escape) && pausable)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void OnDestroy()
    {
        playButton.onClick.RemoveAllListeners();
        mainMenuSettingsButton.onClick.RemoveAllListeners();
        mainMenuCreditsButton.onClick.RemoveAllListeners();
        mainMenuExitButton.onClick.RemoveAllListeners();

        continueButton.onClick.RemoveAllListeners();
        pauseSettingsButton.onClick.RemoveAllListeners();
        pauseCreditsButton.onClick.RemoveAllListeners();
        pauseExitButton.onClick.RemoveAllListeners();
        pauseBackButton.onClick.RemoveAllListeners();

        settingsBackButton.onClick.RemoveAllListeners();
        creditsBackButton.onClick.RemoveAllListeners();
    }

    // Botones

    private void Play()
    {
        mainMenuPanel.Close();
        Time.timeScale = 1f;
    }

    private void PauseGame()
    {
        pausePanel.Open();
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void ResumeGame()
    {
        pausePanel.Close();
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void OpenSettings()
    {
        settingsPanel.Open(); // se muestra encima de MainMenu o Pausa, sin cerrarlos
    }

    private void OpenCredits()
    {
        creditsPanel.Open();
    }

    private void BackToMenu()
    {
        pausePanel.Close();
        mainMenuPanel.Open();
        Time.timeScale = 0f;
        isPaused = false;
    }

    private void CloseSettings()
    {
        settingsPanel.Close();
    }

    private void CloseCredits()
    {
        creditsPanel.Close();
    }

    private void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}