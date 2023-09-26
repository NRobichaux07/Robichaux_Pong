using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.None;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            playerRigidbody2D.AddForce(new Vector2(0, speed), ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.None;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            playerRigidbody2D.AddForce(new Vector2(0, -speed), ForceMode2D.Force);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
}
