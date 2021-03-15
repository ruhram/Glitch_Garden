using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControlller : MonoBehaviour
{
    int numberOfAttacker = 0;
    bool timerFinished = false;

    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }

    public void AttackerKilled()
    {
        numberOfAttacker--;
        if(numberOfAttacker <= 0 && timerFinished)
        {

        }
    }
    
    public void levelTimerFinished()
    {
        timerFinished = true;
    }
}
