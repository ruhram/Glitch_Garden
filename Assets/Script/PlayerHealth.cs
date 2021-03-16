using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float baseLives = 3f;
    [SerializeField] int damage = 1;
    float lives;
    Text LivesText;
    // Start is called before the first frame update
    void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        LivesText = GetComponent<Text>();
        UpdateDisplay();
        Debug.Log("Difficulty setting is currrently" + PlayerPrefsController.GetDifficulty());
    }

    private void UpdateDisplay()
    {
        LivesText.text = lives.ToString();
    }

    public void TakeLives()
    {
        lives -= damage;
        UpdateDisplay();

        if(lives<= 0)
        {
            FindObjectOfType<LevelControlller>().HandleLoseCondition();
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
