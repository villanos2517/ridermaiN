using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Text timeText;
    public Text surfaceSpeedText;
    public Text carSpeedText;
    public Text currentTimeText;
    public Text fastTimeText;
    public Text coinText; // 코인 개수 표시용 텍스트
    public GameObject panel;

    private int coinCount = 0; // 코인 개수

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform.root.gameObject); // 부모(최상위) 오브젝트에 적용
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateTimeText(string time)
    {
        timeText.text = time;
    }

    public void UpdateSurfaceText(string speed)
    {
        surfaceSpeedText.text = speed;
    }

    public void UpdateCarSpeedText(string speed)
    {
        carSpeedText.text = speed;
    }

    public void UpdateCurrentTimeText(string time)
    {
        currentTimeText.text = time;
    }

    public void UpdateFastTimeText(string time)
    {
        fastTimeText.text = time;
    }

    public void UpdateCoinText(int coinCount)
    {
        if (coinText != null)
            coinText.text = $"Coin : {coinCount}";
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinText(coinCount);
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }

    public void GameRestart()
    {
        GameManager.Instance.GameRestart();
    }
}
