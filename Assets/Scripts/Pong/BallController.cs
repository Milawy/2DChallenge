using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallController : MonoBehaviour
{
    #region Variables

    [Header("Score Manager")]
    public PongScoreManager pongScoreManager;

    [Header("UI")]
    public TextMeshProUGUI ThreeTwoOneCountDownUI;

    [Header("Forces")]
    public float XDefaultForce = 15;
    public float YDefaultForce = 10;

    [Header("Booleans")]
    public bool gameOver = false;
    public bool countingDown = true;
    public bool coroutineRunning = false;

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameOver = false;
            countingDown = true;

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.localPosition = new Vector2(0, 0);
            pongScoreManager.ResetScore();

            StartCoroutine(StartCountdown());
        }
    }

    private void FixedUpdate()
    {
        if (!countingDown)
        {
            if (GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0) && !gameOver)
            {
                float randomNumber = Random.Range(0, 2);
                if (randomNumber <= 0.5f)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(XDefaultForce, YDefaultForce));
                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-XDefaultForce, -YDefaultForce));
                }
            }
        }
        else if(!coroutineRunning)
        {
            StartCoroutine(StartCountdown());
        }
    }

    IEnumerator StartCountdown()
    {
        coroutineRunning = true;
        ThreeTwoOneCountDownUI.enabled = true;

        ThreeTwoOneCountDownUI.text = "3";

        yield return new WaitForSeconds(1);

        ThreeTwoOneCountDownUI.text = "2";

        yield return new WaitForSeconds(1);

        ThreeTwoOneCountDownUI.text = "1";

        yield return new WaitForSeconds(1);

        ThreeTwoOneCountDownUI.text = "GO";

        yield return new WaitForSeconds(0.5f);

        ThreeTwoOneCountDownUI.enabled = false;
        coroutineRunning = false;
        countingDown = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PongBar")
        {
            pongScoreManager.UpdateScore();

            if (pongScoreManager.displayVictoryUI)
            {
                gameOver = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            if (GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0));
            }
            else
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0));
            }
        }

        if (collision.collider.tag == "LeftRightPongWall")
        {
            gameOver = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            pongScoreManager.pongLoseUI.SetActive(true);
        }
    }
}