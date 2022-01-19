using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public int ScoreToWin = 10;
    public static GameSystem Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        Instance ??= this;
    }
}
