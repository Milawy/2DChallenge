using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScriptsStates : MonoBehaviour
{
    void Update()
    {
        bool isPongPlayer = GetComponent<PongPlayerController>();
        bool isPongBall = GetComponent<BallController>();
        
        if (isPongPlayer)
        {
            if (gameObject.name == "PongLeftPlayer")
            {
                if (GetComponent<PongPlayerController>().enabled == false)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    transform.localPosition = new Vector2(-7, 0);
                }
            }

            else if (gameObject.name == "PongRightPlayer")
            {
                if (GetComponent<PongPlayerController>().enabled == false)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    transform.localPosition = new Vector2(7, 0);
                }
            }
        }

        else if (isPongBall)
        {
            if (GetComponent<BallController>().enabled == false)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
