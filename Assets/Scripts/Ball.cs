using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public GameObject puck;
    public Rigidbody2D puckRB;
    private Vector2 puckDirection;
    public GameObject labelTextP1;
    public GameObject labelTextP2;
    public bool isPuckGoingRight;
    public TMP_Text p1ScoreText;
    public TMP_Text p2ScoreText;
    public float playTime;
    public int p1Score;
    public int p2Score;
    public GameObject p1Bar;
    public GameObject p2Bar;
    private Vector2 p1InitPosition;
    private Vector2 p2InitPosition;


    // Start is called before the first frame update
    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
        p1InitPosition = p1Bar.transform.position;
        p2InitPosition = p2Bar.transform.position;
        isPuckGoingRight = true;
        playTime += Time.realtimeSinceStartup;
        p1Score = 0;
        p2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            labelTextP1.SetActive(false);
            labelTextP2.SetActive(false);
            puckRB.constraints = RigidbodyConstraints2D.None;
            puckRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            float x = Random.Range(0f, 10f);
            float y = 10f;
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
        }
        if (Input.GetKeyDown(KeyCode.Space) && playTime > 0)
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WallTop")
        {
            if (isPuckGoingRight == true)
            {
                float x = Random.Range(0f, 10f);
                float y = -10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
            }
            if (isPuckGoingRight == false)
            {
                float x = Random.Range(-10f, 0f);
                float y = -10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
            }
        }

        if (collision.gameObject.tag == "WallBottom")
        {
            if (isPuckGoingRight == true)
            {
                float x = Random.Range(0f, 10f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
            }
            if (isPuckGoingRight == false)
            {
                float x = Random.Range(-10f, 0f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
            }
        }

        if (collision.gameObject.tag == "Player1")
        {
            float x = 10f;
            float y = Random.Range(0f, 10f);
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
            isPuckGoingRight = true;
        }

        if (collision.gameObject.tag == "Player2")
        {
            float x = -10f;
            float y = Random.Range(-10f, 0f);
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
            isPuckGoingRight = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreLineLeft")
        {
            p2Score += 1;
            p2ScoreText.SetText("" + p2Score);
            puck.transform.position = new Vector2(6.7f, 0f);
            puckRB.constraints = RigidbodyConstraints2D.FreezeAll;
            labelTextP1.SetActive(true);
            labelTextP2.SetActive(true);
            isPuckGoingRight = false;
            p1Bar.transform.position = p1InitPosition;
            p2Bar.transform.position = p2InitPosition;
        }
        if (collision.gameObject.tag == "ScoreLineRight")
        {
            p1Score += 1;
            p1ScoreText.SetText("" + p1Score);
            puck.transform.position = new Vector2(-6.7f, 0f);
            puckRB.constraints = RigidbodyConstraints2D.FreezeAll;
            labelTextP1.SetActive(true);
            labelTextP2.SetActive(true);
            isPuckGoingRight = true;
            p1Bar.transform.position = p1InitPosition;
            p2Bar.transform.position = p2InitPosition;
        }
    }
}
