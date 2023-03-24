using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitVisual : MonoBehaviour
{
   
    [SerializeField]private GameObject full;
    [SerializeField]private GameObject cut;

    [SerializeField]private GameObject prefabEffect;

    [SerializeField]private ParticleSystem partikelJuice;

    

    // [SerializeField]private GameObject cutEffect;

    
    private void Start() {
        full.gameObject.SetActive(true);
        cut.gameObject.SetActive(false);
        // cutEffect.gameObject.SetActive(false);

        // fullFruitCollider.enabled = true;
    }

    public void GetCutted(){
        full.gameObject.SetActive(false);
        cut.gameObject.SetActive(true);
        partikelJuice.Play();

        
        // cutEffect.gameObject.SetActive(true);
    }
    public void SpawnCutEffectRotation(float angleCutted){
        GameObject cuteffect = Instantiate(prefabEffect);
        cuteffect.transform.position = full.transform.position;
        cuteffect.transform.rotation = Quaternion.Euler(0,0, angleCutted);
    }


}
