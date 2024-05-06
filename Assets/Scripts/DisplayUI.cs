using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour
{
    //Singleton
    public static DisplayUI Instance;
    private void Awake()
    {
        Instance = this;
    }


    public Text timeText, diamondsText, redKeysText, greenKeysText, goldKeysText;
    public Image freezeImage;

    public Text infoText;

    public GameObject gameOverPanel, winPanel, pausePanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        timeText.text = GameManager.Instance.time.ToString();
        diamondsText.text = GameManager.Instance.Diamonds.ToString();
        redKeysText.text = GameManager.Instance.RedKeys.ToString();
        greenKeysText.text = GameManager.Instance.GreenKeys.ToString();
        goldKeysText.text = GameManager.Instance.GoldKeys.ToString();
    }

    public void DisplayFreeze(bool freeze)
    {
        freezeImage.enabled = freeze;
    }

    public void DisplayGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void DisplayPause()
    {
        pausePanel.SetActive(true);
    }

    public void DisplayWin()
    {
        winPanel.SetActive(true);
    }
}

