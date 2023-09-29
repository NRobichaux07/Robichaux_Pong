using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D puckRB;
    public Vector2 puckDirection;
    public GameObject labelTextP1;
    public GameObject labelTextP2;
    // Start is called before the first frame update
    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            labelTextP1.SetActive(false);
            labelTextP2.SetActive(false);
            float x = Random.Range(0f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WallTop")
        {
            float x = Random.Range(0f, 10f);
            float y = -10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
        }

        if (collision.gameObject.tag == "WallBottom")
        {
            float x = Random.Range(-10f, 0f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
        }

        if (collision.gameObject.tag == "Player1")
        {
            float x = 10f;
            float y = Random.Range(0f, 10f);
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
        }

        if (collision.gameObject.tag == "Player2")
        {
            float x = -10f;
            float y = Random.Range(-10f, 0f);
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
        }
    }
}
