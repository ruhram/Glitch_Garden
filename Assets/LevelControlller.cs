using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControlller : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttacker = 0;
    bool timerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
    }
    public void AttackerSpawned()
    {
        numberOfAttacker++;
    }

    public void AttackerKilled()
    {
        numberOfAttacker--;
        if(numberOfAttacker <= 0 && timerFinished)
        {
            StartCoroutine(HandelWinCondition());
        }
    }
    
    IEnumerator HandelWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();

    }
    public void levelTimerFinished()
    {
        timerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawners)
        {
            spawner.stopSpawning();
        }
    }
}
