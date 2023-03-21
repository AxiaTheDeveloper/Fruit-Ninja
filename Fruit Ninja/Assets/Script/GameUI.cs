using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField]private Image BG;
    [SerializeField]private TextMeshProUGUI gameStart_UIText;
    [SerializeField]private TextMeshProUGUI pressLeftMouse_UIText;
    [SerializeField]private TextMeshProUGUI bestScore_Text;
    [SerializeField]private TextMeshProUGUI gameOver_UIText;
    [SerializeField]private TextMeshProUGUI finalScore_Text;

    
    private void Start() {
        // ShowGameStart(true);
        gameWaitingStartUI(true);
        finalScore_Text.gameObject.SetActive(false);
        gameOver_UIText.gameObject.SetActive(false);
        // StartCoroutine(GameStartScreenOff());
        // gameOverStartUI(false);
        BG.color = Color.gray;
        FruitNinjaGameManager.Instance.OnStateChanged += Fruit_OnStateChanged;
        FruitNinjaGameManager.Instance.OnInteractStartGame += Fruit_OnInteractStartGame;
    }

    private void Fruit_OnInteractStartGame(object sender, System.EventArgs e){
        gameWaitingStartUI(false);
        StartCoroutine(GameStartScreenOff());
        
    }
    private void Fruit_OnStateChanged(object sender, System.EventArgs e){

        if(FruitNinjaGameManager.Instance.IsGameOver()){
            gameObject.SetActive(true);
            StartCoroutine(GameOverScreenOn());
        }
        else{
            StartCoroutine(GameOverScreenOff());
        }
        
        
    }
    

    private IEnumerator GameStartScreenOff(){
        float timeElapsed = 0f;
        float duration = 0.5f;
        yield return new WaitForSeconds(0.5f);
        while(timeElapsed < duration){
            Debug.Log("Start");
            float t = Mathf.Clamp01(timeElapsed/duration);
            BG.color = Color.Lerp(Color.grey, Color.clear, t);
            Time.timeScale = 1f - t;
            timeElapsed += Time.unscaledDeltaTime;
            
            yield return null;
        }
        Time.timeScale = 1f;
        
        gameObject.SetActive(false);
    }

    private void gameWaitingStartUI(bool show){

        gameStart_UIText.gameObject.SetActive(show);
        pressLeftMouse_UIText.gameObject.SetActive(show);
        bestScore_Text.text = "Best Score: " + FruitNinjaScoreGameManager.Instance.GetBestScorePlayer().ToString();
        bestScore_Text.gameObject.SetActive(show);
    }
    private void gameOverStartUI(bool show){

        gameOver_UIText.gameObject.SetActive(show);
        pressLeftMouse_UIText.gameObject.SetActive(show);
        bestScore_Text.text = "Best Score: " + FruitNinjaScoreGameManager.Instance.GetBestScorePlayer().ToString();
        bestScore_Text.gameObject.SetActive(show);
        finalScore_Text.text = "Final Score: " + FruitNinjaScoreGameManager.Instance.GetScorePlayer().ToString();
        finalScore_Text.gameObject.SetActive(show);
    }
    

    private IEnumerator GameOverScreenOn(){
        float timeElapsed = 0f;
        float duration = 0.5f;

        while(timeElapsed < duration){
            float t = Mathf.Clamp01(timeElapsed/duration);
            BG.color = Color.Lerp(Color.clear, Color.grey, t);
            Time.timeScale = 1f - t;
            timeElapsed += Time.unscaledDeltaTime;
            
            yield return null;
        }
        Time.timeScale = 1f;
        gameOverStartUI(true);
    }

    private IEnumerator GameOverScreenOff(){
        gameOverStartUI(false);
        float timeElapsed = 0f;
        float duration = 0.5f;
        // yield return new WaitForSeconds(0.5f);
        while(timeElapsed < duration){
            // Debug.Log("Start");
            float t = Mathf.Clamp01(timeElapsed/duration);
            BG.color = Color.Lerp(Color.grey, Color.clear, t);
            Time.timeScale = 1f - t;
            timeElapsed += Time.unscaledDeltaTime;
            
            yield return null;
        }
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

}

