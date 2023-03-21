using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitNinjaScoreGameManager : MonoBehaviour
{
    public static FruitNinjaScoreGameManager Instance {get; private set;}
    public event EventHandler OnScoreAdd;

    private const string PLAYER_PREFS_BEST_SCORE = "BESTSCORPLAYER";
    private int scorePlayer;
    private int bestScorePlayer;

    private void Awake() {
        Instance = this;
        bestScorePlayer = PlayerPrefs.GetInt(PLAYER_PREFS_BEST_SCORE, 0);
    }
    private void Start() {
        restartGameScore();
        OnScoreAdd?.Invoke(this,EventArgs.Empty);

        FruitNinjaGameManager.Instance.OnStateChanged += Fruit_OnStateChanged;
    }

    public void AddScorePlayer(int point){
        scorePlayer += point;
        OnScoreAdd?.Invoke(this,EventArgs.Empty);
    }
    public void restartGameScore(){
        scorePlayer = 0;
    }

    public int GetScorePlayer(){
        return scorePlayer;
    }
    public int GetBestScorePlayer(){
        return bestScorePlayer;
    }

    private void Fruit_OnStateChanged(object sender, System.EventArgs e){
        
            if(scorePlayer > bestScorePlayer){
                bestScorePlayer = scorePlayer;
                PlayerPrefs.SetInt(PLAYER_PREFS_BEST_SCORE, bestScorePlayer);
            }
        
 
    }
}
