using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public int Diamonds => diamonds;
    public int RedKeys => keys_red;
    public int GoldKeys => keys_gold;
    public int GreenKeys => keys_green;

    public int time = 60;
    bool paused;
    bool over;

    int diamonds;
    int keys_red, keys_green, keys_gold;

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }
    private void Update()
    {
        if(over)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
            return;
        }

        //Input.GetKeyDown(KeyCode.Escape)
        if(Input.GetButtonDown("Cancel"))
        {
            if (paused)
                Resume();
            else
                Pause();

            paused = !paused;
        }
    }

    // Time
    void Pause()
    {
        Time.timeScale = 0;
    }
    void Resume()
    {
        Time.timeScale = 1;
    }
    void Stopper()
    {
        DisplayUI.Instance.DisplayFreeze(false);
        time--;
        if (time <= 0)
        {
            // Game over
            CancelInvoke(nameof(Stopper));
            Time.timeScale = 0;
            DisplayUI.Instance.DisplayGameOver();
            over = true;
        }
    }
    public void Win()
    {
        over = true;
        Time.timeScale = 0;
        CancelInvoke(nameof(Stopper));
        DisplayUI.Instance.DisplayWin();
    }

    // Pickups
    public void AddDiamond()
    {
        diamonds++;
    }
    public void AddKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Red:
                keys_red++;
                break;
            case KeyColor.Green:
                keys_green++;
                break;
            case KeyColor.Gold:
                keys_gold++;
                break;
        }
    }
    public void AddTime(int time)
    {
        this.time += time;
        if(this.time <= 0)
        {
            this.time = 1;
        }
    }
    public void FreezeTime(int time)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), time, 1);
        DisplayUI.Instance.DisplayFreeze(true);
    }

    public bool HasKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Red:
                return keys_red > 0;
            case KeyColor.Green:
                return keys_green > 0;
            case KeyColor.Gold:
                return keys_gold > 0;
        }
        return false;
    }
    public void UseKey(KeyColor keyColor)
    {
        switch (keyColor)
        {
            case KeyColor.Red:
                keys_red--;
                break;
            case KeyColor.Green:
                keys_green--;
                break;
            case KeyColor.Gold:
                keys_gold--;
                break;
        }
    }
}
