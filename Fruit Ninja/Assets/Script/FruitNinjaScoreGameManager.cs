using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitNinjaScoreGameManager : MonoBehaviour
{
    public static FruitNinjaScoreGameManager Instance {get; private set;}
    public event EventHandler OnScoreAdd;

    private int scorePlayer;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        scorePlayer = 0;
        OnScoreAdd?.Invoke(this,EventArgs.Empty);
    }

    public void AddScorePlayer(int point){
        scorePlayer += point;
        OnScoreAdd?.Invoke(this,EventArgs.Empty);
    }

    public int GetScorePlayer(){
        return scorePlayer;
    }
}
