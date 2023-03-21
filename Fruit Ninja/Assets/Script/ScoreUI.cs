using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI score_Text;
    

    private void Start() {
        FruitNinjaScoreGameManager.Instance.OnScoreAdd +=FruitNinja_OnScoreAdd;
    }

    private void FruitNinja_OnScoreAdd(object sender, System.EventArgs e){
        UpdateScoreVisual();
    }

    private void UpdateScoreVisual(){
        score_Text.text = "Score: " + FruitNinjaScoreGameManager.Instance.GetScorePlayer().ToString(); 
    }
}
