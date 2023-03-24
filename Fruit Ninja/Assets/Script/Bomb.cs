using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bomb : MonoBehaviour
{   
    private const string COLLIDER_PLAYER = "Player";
    [SerializeField]private GameObject Explode; 
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(COLLIDER_PLAYER)){
            // Cutted();
            KnifeBehaviour knife = other.GetComponent<KnifeBehaviour>();
            AudioManager.Instance.PlayWarningSound(knife.transform.position);
            FruitNinjaGameManager.Instance.gameOver();


            GameObject cuteffect = Instantiate(Explode); 
            cuteffect.transform.position = transform.position;
            
        }

    }

}
