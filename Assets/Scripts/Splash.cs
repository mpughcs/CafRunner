// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// Splash Screen Code
//This code handles the little cut scene that happens when the player starts the game. 
//uses couroutine to time a scene change. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 3f;

    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Play");
    }
}
