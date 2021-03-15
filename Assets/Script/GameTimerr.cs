using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimerr : MonoBehaviour
{
    [SerializeField] float LevelTime = 10f;
    bool trigeredLevelFinished = false;
    // Update is called once per frame
    void Update()
    {
        if (trigeredLevelFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= LevelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelControlller>().levelTimerFinished();
            trigeredLevelFinished = true;
        }
    }
}