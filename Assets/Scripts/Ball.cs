using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    private bool isPlaying;
    public int p1Score;
    public int p2Score;
    public GameObject p1Bar;
    public GameObject p2Bar;
    private Vector2 p1InitPosition;
    private Vector2 p2InitPosition;
    public GameObject p1Win;
    public GameObject p2Win;
    public GameObject playAgain;
    public GameObject winSFX;

    // Start is called before the first frame update
    void Start()
    {
        puckRB = GetComponent<Rigidbody2D>();
        p1InitPosition = p1Bar.transform.position;
        p2InitPosition = p2Bar.transform.position;
        isPuckGoingRight = true;
        isPlaying = false;
        p1Score = 0;
        p2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isPlaying == false)
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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isPlaying = true;
        }
        if (p1Score == 5)
        {
            winSFX.SetActive(true);
            p1Win.SetActive(true);
            playAgain.SetActive(true);
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        if (p2Score == 5)
        {
            winSFX.SetActive(true);
            p2Win.SetActive(true);
            playAgain.SetActive(true);
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WallTop")
        {
            if (isPuckGoingRight == true)
            {
                float x = Random.Range(5f, 10f);
                float y = -10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
            }
            if (isPuckGoingRight == false)
            {
                float x = Random.Range(-10f, -5f);
                float y = -10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
            }
        }

        if (collision.gameObject.tag == "WallBottom")
        {
            if (isPuckGoingRight == true)
            {
                float x = Random.Range(5f, 10f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
            }
            if (isPuckGoingRight == false)
            {
                float x = Random.Range(-10f, -5f);
                float y = 10f;
                puckDirection = new Vector2(x, y);
                puckRB.AddForce(puckDirection, ForceMode2D.Force);
            }
        }

        if (collision.gameObject.tag == "Player1")
        {
            float x = 10f;
            float y = Random.Range(5f, 10f);
            puckDirection = new Vector2(x, y);
            puckRB.AddForce(puckDirection, ForceMode2D.Force);
            isPuckGoingRight = true;
        }

        if (collision.gameObject.tag == "Player2")
        {
            float x = -10f;
            float y = Random.Range(-10f, -5f);
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
            isPlaying = false;
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
            isPlaying = false;
        }
    }
}
