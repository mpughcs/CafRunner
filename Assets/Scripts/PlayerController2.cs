// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// PlayerController Code
//This Code handles everything having to do with player movement
//as well as item pickups and power-up effects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    // Variables are initiated and outside and during the start method

    public float speed = 10f;
    public float jumpSpeed = 10f;
    Vector3 characterDirection;
    float characterScaleX;
    public Animator animations;
    private float boostTimer;
    private bool isBoosting;
    public GameObject keyImage;
    public GameObject CholulaImage;
    public static bool hasKey = false;
    new AudioSource audio;
    private Rigidbody2D player;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        characterDirection = transform.localScale;
        characterScaleX = characterDirection.x;
        animations = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        boostTimer = 0;
        isBoosting = false;

    }


    // Calls every method I want to Happen Every Frame
    void FixedUpdate()
    {
        Jump();
        SwitchDirection();
        MoveHoriz();
        HandleBoostTime();

    }

    //controls what happens when the player hits trigger objects with tags, 'Cholula' and 'Key'
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cholula"))
        {
            other.gameObject.SetActive(false);

            isBoosting = true;
            speed += Cholula.GetEffectSpeed();

        }
        else
        {
            isBoosting = false;
            boostTimer = 0;

        }

        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);

            hasKey = true;

        }

    }


    private void Update()
    {
        Jump();
        KeyInPocket();
        Debug.Log(isBoosting);
        Debug.Log("boostTimer: "+boostTimer);



    }


    //this method is in charge of handling the boost effect
    void HandleBoostTime()
    {
        if (isBoosting)
        {
            CholulaImage.SetActive(true);
            boostTimer += Time.deltaTime;
            if (boostTimer >= Cholula.GetEffectTime())
            {
                speed = 10f;
                isBoosting = false;
                boostTimer = 0;
                CholulaImage.SetActive(false);


            }
        }



    }
    //this method handles horizontal movement
    void MoveHoriz()
    {
        float xPosition = transform.position.x + (Input.GetAxis("Horizontal") * speed) * Time.deltaTime;
        Vector3 newPosition = new Vector3(xPosition, transform.position.y, 0f);
        transform.position = newPosition;

    }
    //this method scales the player's transform to have them facing the way they are moving
    void SwitchDirection()
    {
        if (Input.GetAxis("Horizontal") != 0f)
        {
            animations.SetBool("isMoving", true);
            animations.SetBool("isJumping", false);
        }
        else
        {
            animations.SetBool("isMoving", false);

        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterDirection.x = -characterScaleX;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterDirection.x = characterScaleX;
        }
        transform.localScale = characterDirection;
    }
    //this method is responsible for jumping
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(player.velocity.y) < 0.001f)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
            audio.Play(0);
        }
        if (Mathf.Abs(player.velocity.y) > 0.001f)
        {
            animations.SetBool("isJumping", true);

        }
        else if (Mathf.Abs(player.velocity.y) < 0.001f)
        {
            animations.SetBool("isJumping", false);

        }

    }
    //this method shows a key on the canvas if the player has it in their possesion
    void KeyInPocket()
    {
        if (hasKey)
        {
            keyImage.SetActive(true);

        }
        else
        {
            keyImage.SetActive(false);

        }
    }



}