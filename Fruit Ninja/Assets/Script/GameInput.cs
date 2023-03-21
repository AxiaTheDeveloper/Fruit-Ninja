using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private bool checkMouseDown = false;
    private bool checkMouseUp = false;

    // Update is called once per frame
    public bool GetMouseDown(){
        if(Input.GetMouseButtonDown(0)){
            checkMouseDown = true;
        }
        else{
            checkMouseDown = false;
        }
        return checkMouseDown;
    }
    public bool GetMouseUp(){
        if(Input.GetMouseButtonUp(0)){
            checkMouseUp = true;
        }
        else{
            checkMouseUp = false;
        }
        return checkMouseUp;
    }
}
