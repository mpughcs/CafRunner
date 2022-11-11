// Max Pugh
// 2354296
// mpugh@chapman.edu
// CPSC 236 - 02
// Assignment: Final
// MovingPlatform class
//This Code is similar to the footballer class and moves a platform back and forth
//the speed and distance of such can be set in the editor

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Transform platform;
    public float moveDistance;
    public float moveSpeed;
    private float initialPosition;
    private int movementDirection=1;
    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Transform>();
        initialPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }
    void MovePlatform(){

        if(Mathf.Abs(transform.position.x-initialPosition)>=moveDistance){
            movementDirection = movementDirection * -1;

        }
        float xPosition = transform.position.x + (moveSpeed*movementDirection) * Time.deltaTime;
        Vector2 platformMove = new Vector2(xPosition, transform.position.y);
        transform.position = platformMove;

       
    }
}
