
// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// Menu Class
//This code handles all menu navigation for each navigable menu in the game. 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnStartButtonPress(){
        SceneManager.LoadScene("SplashAlert");
    }
    public void OnInstructionButtonPress()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void OnBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnQuitButtonPress()

    {

        Application.Quit();
    }
}
