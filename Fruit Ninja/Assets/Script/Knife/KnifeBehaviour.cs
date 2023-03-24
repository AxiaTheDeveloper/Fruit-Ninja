using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : MonoBehaviour
{   
    public static KnifeBehaviour Instance{get; private set;}
    
    [SerializeField]private GameInput gameInput;
    [SerializeField]private KnifeVisual knifeVisual;
    private bool isUseKnife = false;
    private Collider2D knifeCollider;
    private Vector3 perpindahanKnife;
    [SerializeField]private float kecepatanKnifeMin, cutForce;

    private void Awake() {
        knifeCollider = GetComponent<Collider2D>();
        Instance = this;
    }

    void Update()
    {
        if(FruitNinjaGameManager.Instance.IsGameStart()){
            if(gameInput.GetMouseDown()){
                StartUsingKnife();
            }
            else if(gameInput.GetMouseUp()){
                StoptUsingKnife();
            }
            if(isUseKnife){
                UsingKnife();
            }
        // Debug.Log(knifeCollider.enabled);    
        }
        
    }

    private void OnEnable() {
        StoptUsingKnife();
    }
    private void OnDisable() {
        StoptUsingKnife();
    }
    private void StartUsingKnife(){
        Vector2 mousePositionV2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mousePositionV3 = new Vector3(mousePositionV2.x,mousePositionV2.y, 0);
        perpindahanKnife = mousePositionV3 - transform.position;
        
        transform.position = mousePositionV3;

        isUseKnife = true;
        knifeCollider.enabled = true;
        knifeVisual.bladeTrailOn();
    }
    private void StoptUsingKnife(){
        isUseKnife = false;
        knifeCollider.enabled = false;
        knifeVisual.bladeTrailOff();
    }
    private void UsingKnife(){
        Vector2 mousePositionV2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mousePositionV3 = new Vector3(mousePositionV2.x,mousePositionV2.y, 0);
        perpindahanKnife = mousePositionV3 - transform.position;
        
        // Debug.Log(perpindahanKnife + " " + perpindahanKnife.magnitude);

        float kecepatanKnife = perpindahanKnife.magnitude / Time.deltaTime;

        knifeCollider.enabled = kecepatanKnife > kecepatanKnifeMin;

        transform.position = mousePositionV3;

    }

    public Vector3 GetPerpindahanKnife(){
        return perpindahanKnife;
    }
    public float GetCutForce(){
        return cutForce;
    }

}
