using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCuttedVisual : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField]private FruitVisual fruitVisual;
    [SerializeField]private float fruitLifeTime;
    private Animator animatorController;
    private const string CUT = "Cut";



    private void Awake() {
        animatorController = GetComponent<Animator>();
    }
    private void OnEnable() {
        animatorController.SetTrigger(CUT);
    }

    void Update()
    {
        Destroy(gameObject, fruitLifeTime);
    }
}
