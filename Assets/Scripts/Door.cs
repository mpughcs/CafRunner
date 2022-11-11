// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// Door class
//this Class handles logic for whether a player can enter a door and what happens if they do
//checks if the player has a key when trying to enter a door, makes a lock appear if they do not. 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    public GameObject doorText;
    public GameObject lockImage;
    private bool isEnterable;
 
    // Update is called once per frame
    void Update()
    {
        EnterDoor();
    }
	private void OnCollisionStay2D(Collision2D collision)
	{
        if(collision.gameObject.CompareTag("Player")){
            doorText.SetActive(true);
        }
        StartCoroutine(VanishDoorText());

	}
   
    private IEnumerator VanishDoorText()
    {
        isEnterable = true;
        yield return new WaitForSeconds(3);
        doorText.SetActive(false);
        isEnterable = false;
        lockImage.SetActive(false);



    }
    void EnterDoor(){
        
            if (isEnterable && Input.GetKeyDown(KeyCode.E))
            {
                if(PlayerController2.hasKey==true){
                    SceneManager.LoadScene("FinalStretch");
                    PlayerController2.hasKey = false;
                }else
                {
                    lockImage.SetActive(true);
                }
            }
    }
}
