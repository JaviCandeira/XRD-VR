using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int theScore;
    public int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        theScore = 0;
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    public void incrementScore(){
            currentScore+= 1;
            theScore= currentScore;
            scoreText.text = "SCORE: " + theScore;
    }

}
