using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private Slider PlayerHealthSlider;
    [SerializeField] private TMP_Text healthText;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    [SerializeField] private TMP_Text timerText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateHealthSlider()
    {
        PlayerHealthSlider.maxValue = PlayerController.Instance.playerMaxVida;
        PlayerHealthSlider.value = PlayerController.Instance.playerVida;
        healthText.text = PlayerHealthSlider.value + " / " + PlayerHealthSlider.maxValue;
    }
    public void UpdateTimer(float timer)
    {
        float min = Mathf.FloorToInt(timer / 60f);
        float sec = Mathf.FloorToInt(timer % 60f);

        timerText.text = min + ":" + sec.ToString("00");
    }
}

