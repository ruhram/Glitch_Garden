using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimerr : MonoBehaviour
{
    [SerializeField] float LevelTime = 10f;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / LevelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= LevelTime);
        if (timerFinished)
        {
            Debug.Log("Finished");
        }
    }
}