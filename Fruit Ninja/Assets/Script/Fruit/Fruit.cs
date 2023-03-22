using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fruit : MonoBehaviour
{

    private Rigidbody2D rigidFruit;
    private Collider2D fullFruitCollider;

    [SerializeField]private FruitVisual fruitVisual;

    [SerializeField]private GameObject Cut; 

    

    private const string COLLIDER_PLAYER = "Player";

    public event EventHandler OnCutScoreFruit;
    
    private void Awake() {
        rigidFruit = GetComponent<Rigidbody2D>();
        fullFruitCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(COLLIDER_PLAYER)){
            // Cutted();
            KnifeBehaviour knife = other.GetComponent<KnifeBehaviour>();
            
            OnCutScoreFruit?.Invoke(this, EventArgs.Empty);
            Cutted(knife.GetPerpindahanKnife(),knife.transform.position,knife.GetCutForce());
            AudioManager.Instance.PlayChoppingSound(knife.transform.position);
        }
    }

    private void Cutted(Vector3 arahKnife, Vector3 posisiKnifeKena, float forceKnife){
        fruitVisual.GetCutted();
        fullFruitCollider.enabled = false;

        float angleCutted = Mathf.Atan2(arahKnife.y, arahKnife.x) * Mathf.Rad2Deg;

        // Debug.Log("angle" + angleCutted);
        Cut.transform.rotation = Quaternion.Euler(0,0, angleCutted);
        fruitVisual.SpawnCutEffectRotation(angleCutted);

        Rigidbody2D[] rigidSlicedFruits = Cut.GetComponentsInChildren<Rigidbody2D>();

        foreach(Rigidbody2D slicedFruit in rigidSlicedFruits){
            slicedFruit.velocity = rigidFruit.velocity;

            // Debug.Log(arahKnife + ".." + forceKnife + ".." + posisiKnifeKena);
            slicedFruit.AddForceAtPosition(arahKnife * forceKnife, posisiKnifeKena);
        }




    }
}
