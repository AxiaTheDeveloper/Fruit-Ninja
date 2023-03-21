using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCuttedVisual : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float fruitLifeTime;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, fruitLifeTime);
    }
}
