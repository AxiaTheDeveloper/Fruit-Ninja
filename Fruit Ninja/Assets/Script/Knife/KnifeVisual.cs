using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeVisual : MonoBehaviour
{
    [SerializeField]private TrailRenderer trailKnife;
    

    private void Awake() {
        // trailKnife = GetComponentInChildren<TrailRenderer>();
    }

    public void bladeTrailOn(){
        trailKnife.enabled = true;
        trailKnife.Clear();
    }
    public void bladeTrailOff(){
        trailKnife.enabled = false;
    }

}
