using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{   
    private const string COLLIDER_PLAYER = "Player";

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(COLLIDER_PLAYER)){
            // Cutted();
            KnifeBehaviour knife = other.GetComponent<KnifeBehaviour>();
            
            // OnCutScoreFruit?.Invoke(this, EventArgs.Empty);
            // Cutted(knife.GetPerpindahanKnife(),knife.transform.position,knife.GetCutForce());
        }
    }


}
