using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int lives = 9;
    [SerializeField] int damage = 1;
    Text LivesText;
    // Start is called before the first frame update
    void Start()
    {
        LivesText = GetComponent<Text>();
        UpdateDisplay();
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
