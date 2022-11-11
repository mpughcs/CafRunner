// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// Footballer class
//This class represents and enemy that pushes the player around by running 
//The distance and speed the enemy run can be set in the editor
//the enemy also flips directions when it encounters an obstacle with a specific tag. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootBaller : MonoBehaviour
{
    public float speed = 5f;
    public int defaultDirection = -1;
    public float xConstraint;
    private Rigidbody2D runner;
    Vector3 characterDirection;
    float characterScaleX;



    // Start is called before the first frame update
    void Start()
    {
        runner = GetComponent<Rigidbody2D>();
        characterDirection = transform.localScale;
        characterScaleX = characterDirection.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Run(defaultDirection);
        ConstrainRun();

        SwitchDirection(defaultDirection);
    }
    void Run(int dirrection)
    {
        float xPosition = transform.position.x + (speed * defaultDirection) * Time.deltaTime;
        Vector3 newPosition = new Vector3(xPosition, transform.position.y, 0f);

        transform.position = newPosition;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            defaultDirection = -1 * defaultDirection;
        }

    }
    void ConstrainRun(){
        if(transform.position.x <= xConstraint){
            defaultDirection = -1 * defaultDirection;

        }
    }
    void SwitchDirection(int direction)
    {
        characterDirection.x = -direction*characterScaleX; 
        transform.localScale = characterDirection;

    }
}


