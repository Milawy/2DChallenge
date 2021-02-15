using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletHellPlayerController : MonoBehaviour
{
    #region Variables

    [Header("Manager")]
    public TimerManager timeManager;

    [Header("LimitBorders")]
    public Transform BorderMax;
    public Transform BorderMin;

    [Header("PlayerParameters")]
    public float Speed = 4f;
    public int life = 3;

    [Header("UI")]
    public TextMeshProUGUI LoseUI;
    public TextMeshProUGUI ThreeTwoOneCountDownUI;
    public TextMeshProUGUI LifeUI;

    [Header("Booleans")]
    public bool gameOver = false;
    public bool countingDown = true;
    public bool coroutineRunning = false;

    #endregion

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.R)) RestartGame();
    }

    void Move()
    {
        Vector3 currentPosition = transform.localPosition;

        if (Input.GetAxis("Horizontal") > 0 && currentPosition.x < BorderMax.localPosition.x)
        {
            currentPosition.x += Speed * Time.deltaTime;
        }

        else if (Input.GetAxis("Horizontal") < 0 && currentPosition.x > BorderMin.localPosition.x)
        {
            currentPosition.x -= Speed * Time.deltaTime;
        }

        if (Input.GetAxis("Vertical") > 0 && currentPosition.y < BorderMax.localPosition.y)
        {
            currentPosition.y += Speed * Time.deltaTime;
        }

        else if (Input.GetAxis("Vertical") < 0 && currentPosition.y > BorderMin.localPosition.y)
        {
            currentPosition.y -= Speed * Time.deltaTime;
        }

        transform.localPosition = currentPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (--life == 0)
        {
            gameObject.SetActive(false);
            LoseUI.enabled = true;
        }
        Destroy(collision.gameObject);
    }

    void RestartGame()
    {
        gameObject.SetActive(true);
        gameObject.transform.localPosition = new Vector3(0f, -3f, 0f);
        LoseUI.enabled = false;

        gameOver = false;
        countingDown = true;

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.localPosition = new Vector2(0, 0);
        timeManager.ResetTimer();

        StartCoroutine(StartCountdown());
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
}
