using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMovement : MonoBehaviour
{
    private Rigidbody2D rigidFruit;
    private void Awake() {
        rigidFruit = GetComponent<Rigidbody2D>();
    }
    

    
}
