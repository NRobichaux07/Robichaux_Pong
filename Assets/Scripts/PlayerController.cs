using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody2D.AddForce(new Vector2(0, speed), ForceMode2D.Force);
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody2D.AddForce(new Vector2(0, -speed), ForceMode2D.Force);
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

}