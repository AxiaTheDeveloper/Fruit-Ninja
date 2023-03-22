using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitNinjaGameManager : MonoBehaviour
{
    public static FruitNinjaGameManager Instance {get; private set;}

    // public event EventHandler OnGameStart;

    // public event EventHandler OnGameOver;
    public event EventHandler OnInteractStartGame;
    public event EventHandler OnStateChanged;
    

    // public bool isGameStart = false;
    public enum StateGame{
        WaitingToStart, GameStart, GameOver
    }
    
    private StateGame state;

    [SerializeField]private GameInput gameInput;

    private void Awake() {
        Instance = this;
        state = StateGame.WaitingToStart;
        // Debug.Assert(Instance != null, "GameInput instance is null");
    }
    private void Start() {
        OnInteractStartGame += gameManager_OnInteractStartGame;
        KnifeBehaviour.Instance.enabled = false;
        ObjectSpawner.Instance.enabled = false;
    }

    private void gameManager_OnInteractStartGame(object sender, System.EventArgs e){
        if(state == StateGame.WaitingToStart){
            StartGame();
        }
    }

    private void Update() {
        if(gameInput.InputGameStart() && state == StateGame.WaitingToStart){
            OnInteractStartGame?.Invoke(this, EventArgs.Empty);
        }
        else if(gameInput.InputGameStart() && state == StateGame.GameOver){
            
            StartGame();
            
            RestartGame();
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void RestartGame(){
        FruitNinjaScoreGameManager.Instance.restartGameScore();
        Fruit[] fruits = FindObjectsOfType<Fruit>();
        foreach(Fruit fruit in fruits){
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();
        foreach(Bomb bomb in bombs){
            Destroy(bomb.gameObject);
        }
    }

    public bool IsWaitingToStart(){
        return state == StateGame.GameStart;
    }
    public bool IsGameStart(){
        return state == StateGame.GameStart;
    }


    public bool IsGameOver(){
        return state == StateGame.GameOver;
    }
    

    public void gameOver(){
        KnifeBehaviour.Instance.enabled = false;
        ObjectSpawner.Instance.enabled = false;
        state = StateGame.GameOver;

        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }
    public void StartGame(){
        KnifeBehaviour.Instance.enabled = true;
        ObjectSpawner.Instance.enabled = true;
        state = StateGame.GameStart;
        // Time.timeScale = 1f;
        // Debug.Log("Game Start");
        // OnStateChanged?.Invoke(this, EventArgs.Empty);
    }
        
}

    

