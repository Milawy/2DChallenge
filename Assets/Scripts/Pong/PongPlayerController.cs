using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerController : MonoBehaviour
{
    #region Variables

    [Header("Movement Keys")]
    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;

    [Header("Walls")]
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    [Header("Player Parameters")]
    public float speed = 10f;

    #endregion

    void Update()
    {
        restartButton();
    }

    void restartButton()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameObject.name == "PongLeftPlayer")
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.localPosition = new Vector2(-7, 0);
            }

            else if (gameObject.name == "PongRightPlayer")
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.localPosition = new Vector2(7, 0);
            }
        }
    }

    void FixedUpdate()
    {
        playerMovement();
    }

    void playerMovement()
    {
        if (Input.GetKey(moveUp)) GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        else if (Input.GetKey(moveDown)) GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        else GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
