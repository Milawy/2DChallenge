using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SwitchGame : MonoBehaviour
{
    #region Variables

    public UnityEvent changingGameEvent;

    [Header("Camera Switcher")]
    public SwitchCamera cameraSwitcher;

    [Header("MainGame")]
    public GameObject mainPlayer;
    public MouseLook mouseLook;

    [Header("BulletHell")]
    public BulletHellPlayerController bulletHellPlayer;
    public BulletHellSpawner bulletHellSpawner;
    public BulletHellSpawner bulletHellSpawner2;

    [Header("Pong")]
    public PongPlayerController pongLeftPlayer;
    public PongPlayerController pongRightPlayer;
    public BallController pongBall;
    public PongScoreManager pongScore;
    public GameObject pongScoreUI;
    public GameObject pongVictoryUI;
    public GameObject pongLoseUI;

    [Header("AngryBirds")]
    public BirdController birdsPlayer;
    public GameObject birdsUI;

    [Header("UI")]
    public TextMeshProUGUI KeyToPlayText;

    [Header("Booleans")]
    public bool isInAnotherGame = false;

    #endregion

    void Start()
    {
        mainPlayer.GetComponent<CharacterController>().enabled = true;
        mainPlayer.GetComponent<PlayerMovement>().enabled = true;
        mouseLook.enabled = true;

        bulletHellPlayer.enabled = false;
        bulletHellSpawner.enabled = false;
        bulletHellSpawner2.enabled = false;

        pongLeftPlayer.enabled = false;
        pongRightPlayer.enabled = false;
        pongBall.enabled = false;
        pongScore.enabled = false;
        pongScoreUI.SetActive(false);
        pongVictoryUI.SetActive(false);

        birdsPlayer.enabled = false;
    }

    void Update()
    {
        if (mouseLook.raycastHitting2DGame)
        {
            if(mouseLook.raycastHit.transform.tag == "2DGameScreens" && !isInAnotherGame)
            {
                KeyToPlayText.enabled = true;
                KeyToPlayText.text = "Press F to play " + mouseLook.raycastHit.transform.gameObject.name;

                if (Input.GetKeyDown(KeyCode.F))
                {
                    string gameName = mouseLook.raycastHit.transform.gameObject.name;

                    gameChanger(gameName);
                    changingGameEvent.Invoke();
                }
            }

            else
            {
                KeyToPlayText.enabled = false;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    string gameName = mouseLook.raycastHit.transform.gameObject.name;

                    gameChanger(gameName);
                    changingGameEvent.Invoke();
                }
            }
        }

        else
        {
            KeyToPlayText.enabled = false;
        }
    }

    public void gameChanger(string gameName)
    {
        isInAnotherGame = !isInAnotherGame;
        mainPlayer.GetComponent<CharacterController>().enabled = !mainPlayer.GetComponent<CharacterController>().enabled;
        mainPlayer.GetComponent<PlayerMovement>().enabled = !mainPlayer.GetComponent<PlayerMovement>().enabled;
        mouseLook.enabled = !mouseLook.enabled;

        cameraSwitcher.switchCamera(gameName);

        switch (gameName) {
            case "Bullet Hell":
                bulletHellPlayer.enabled = !bulletHellPlayer.enabled;
                bulletHellSpawner.enabled = !bulletHellSpawner.enabled;
                bulletHellSpawner2.enabled = !bulletHellSpawner2.enabled;
                break;

            case "Pong":
                pongLeftPlayer.enabled = !pongLeftPlayer.enabled;
                pongRightPlayer.enabled = !pongRightPlayer.enabled;
                
                pongBall.enabled = !pongBall.enabled;
                pongBall.gameOver = false;
                pongBall.countingDown = true;

                pongScore.enabled = !pongScore.enabled;
                pongScore.ResetScore();

                pongScoreUI.SetActive(!pongScoreUI.activeSelf);
                pongVictoryUI.SetActive(false);
                pongLoseUI.SetActive(false);

                break;

            case "Happy Birds":
                if (isInAnotherGame) Cursor.lockState = CursorLockMode.None;
                else Cursor.lockState = CursorLockMode.Locked;

                birdsPlayer.enabled = !birdsPlayer.enabled;

                if (birdsPlayer.isVictory)
                {
                    birdsUI.SetActive(false);
                    birdsPlayer.isVictory = false;
                }
                break;

            default:
                break;
        }
    }
}