using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    static float MAX_POS_X = 21f;
    static float MAX_POS_Y = 22.5f;
    static float SPEED = 0.05f;
    static float SPEED_DIAG = SPEED * Mathf.Sin(Mathf.PI / 4) + 0.002f;

    static Vector3 faceright = new Vector3(1, 1, 1);
    static Vector3 faceleft = new Vector3(-1, 1, 1);

    //declaring here making a guess about memory management- 
    //4 booleans ever rather than making new local ones in the method every tick and
    //having them constantly getting garbage collected 
    //this is a guess tho, idk if the compiler would handle local ones better
    bool up, down, left, right = false;
    float effectivespeed;

    // Update is called once per frame
    void Update()
    {

        //only check key once
        up = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        //same speed when diagonal
        if((up || down ) && (left || right)) {
            effectivespeed = SPEED_DIAG;
        } else {
            effectivespeed = SPEED;
        }

        //prevent from going out of bounds
        if(up && transform.position.y < MAX_POS_Y) {
            transform.Translate(0f, effectivespeed, 0f);
        }
        if(down && transform.position.y > -MAX_POS_Y) {
            transform.Translate(0f, -effectivespeed, 0f);
        }
        if(left && transform.position.x > -MAX_POS_X) {
            transform.Translate(-effectivespeed, 0f, 0f);
        }
        if(right && transform.position.x < MAX_POS_X) {
            transform.Translate(effectivespeed, 0f, 0f);
        }

        //flip sprite 
        if(right) {
            transform.localScale = faceright;
        } else if(left) {
            transform.localScale = faceleft;
        }

    }
}
