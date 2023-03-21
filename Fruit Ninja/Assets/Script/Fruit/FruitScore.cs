using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScore : MonoBehaviour
{
    [SerializeField]private int fruitPoint;
    [SerializeField]private Fruit fruit;

    private void Start() {
        fruit.OnCutScoreFruit += Fruit_OnCutScoreFruit;
    }

    private void Fruit_OnCutScoreFruit(object sender, System.EventArgs e){
        FruitNinjaScoreGameManager.Instance.AddScorePlayer(fruitPoint);
    }

}
