using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private Movement playerOneMovement;
    [SerializeField] private Movement playerTwoMovement;

    [SerializeField] private Slider playerOneSlider;
    [SerializeField] private Slider playerTwoSlider;
    [SerializeField] private TMP_Text playerOneSpeedText;
    [SerializeField] private TMP_Text playerTwoSpeedText;

    private void Awake()
    {
        playerOneSlider.onValueChanged.AddListener(OnPlayerOneSliderChanged);
        playerTwoSlider.onValueChanged.AddListener(OnPlayerTwoSliderChanged);
    }

    private void OnEnable()
    {
        playerOneSlider.SetValueWithoutNotify(playerOneMovement.GetSpeed());
        playerOneSpeedText.text = ("P1 Speed: ") + playerOneMovement.GetSpeed().ToString("0.0");

        playerTwoSlider.SetValueWithoutNotify(playerTwoMovement.GetSpeed());
        playerTwoSpeedText.text = ("P2 Speed: ") + playerTwoMovement.GetSpeed().ToString("0.0");
    }

    private void OnDestroy()
    {
        playerOneSlider.onValueChanged.RemoveListener(OnPlayerOneSliderChanged);
        playerTwoSlider.onValueChanged.RemoveListener(OnPlayerTwoSliderChanged);
    }

    public void OnPlayerOneSliderChanged(float value)
    {
        playerOneMovement.SetSpeed(value);
        playerOneSpeedText.text = ("P1 Speed: ") + value.ToString("0.0");
    }

    public void OnPlayerTwoSliderChanged(float value)
    {
        playerTwoMovement.SetSpeed(value);
        playerTwoSpeedText.text = ("P2 Speed: ") + value.ToString("0.0");
    }
}