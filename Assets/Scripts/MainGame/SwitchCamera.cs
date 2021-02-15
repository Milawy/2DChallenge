using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera Main;
    public Camera Pong;
    public Camera BulletHell;
    public Camera HappyBirds;

    public void switchCamera(string gameName)
    {
        switch (gameName)
        {
            case "Pong":
                Main.enabled = !Main.enabled;
                Pong.enabled = !Pong.enabled;
                break;

            case "Bullet Hell":
                Main.enabled = !Main.enabled;
                BulletHell.enabled = !BulletHell.enabled;
                break;

            case "Happy Birds":
                Main.enabled = !Main.enabled;
                HappyBirds.enabled = !HappyBirds.enabled;
                break;

            default:
                break;
        }
    }
}
