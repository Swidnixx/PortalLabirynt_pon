using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating(nameof(Stopper), 3, 1);
    }

    public int time = 60;
    void Stopper()
    {
        time--;
        if (time <= 0)
        {
            CancelInvoke(nameof(Stopper));
            // Game over
        }
    }
}
