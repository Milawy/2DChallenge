using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsManager : MonoBehaviour
{
    public List<GameObject> Doors;
    public BirdController HappyBirdsVictory;
    public PongScoreManager PongVictory;

    public bool HappyBirdsFinished = false;
    public bool PongFinished = false;

    void Update()
    {
        if (HappyBirdsVictory.isVictory && !HappyBirdsFinished)
        {
            HappyBirdsTrigger();
        }
        if (PongVictory.displayVictoryUI && !PongFinished)
        {
            PongTrigger();
        }
    }

    void HappyBirdsTrigger()
    {
        HappyBirdsFinished = true;
        Open(Doors[0]);
    }

    void PongTrigger()
    {
        PongFinished = true;
        Open(Doors[0]);
    }

    void Open(GameObject Door)
    {
        Door.SetActive(false);
        Doors.Remove(Door);
    }
}
