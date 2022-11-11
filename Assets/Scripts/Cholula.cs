// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// Cholula class
//This Class represents the Cholula object and stores the effect parameters
//so they are easily configurable. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cholula : MonoBehaviour
{
    // Start is called before the first frame update
    public static float effectSpeed = 5f;
    public static int effectTime = 5;

    public static float GetEffectSpeed(){
        return effectSpeed;
    }
    public static int GetEffectTime()
    {
        return effectTime;
    }
   
}
