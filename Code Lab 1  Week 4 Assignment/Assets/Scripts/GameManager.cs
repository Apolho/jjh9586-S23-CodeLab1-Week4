using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int score = 0;
    public static int lives = 3;

    

    public static bool game = false;

    public TextMeshProUGUI scoreText, displayText;
    public GameObject canvas;
    

    public List<int> highScores = new List<int>();
    
    //Save Variables
    private const string DIR_DATA = "/Data/"; //what directory will be called
    private const string FILE_HIGH_SCORE = "highScore.txt"; //file where info will be saved
    private string PATH_HIGH_SCORE;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PATH_HIGH_SCORE = Application.dataPath + DIR_DATA + FILE_HIGH_SCORE; //looks for where data can be stored in device
        //first looks for folder then file
    }
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lives > 0) //if lives are above 0, the score text will change
        {
            scoreText.text = "Score: " + score; //make the text say the score and highscore
        }
        else //if lives get below 0
        {
            Destroy(scoreText); //destroys score on the side
            EndScreenMenu(); //calls the end screen function
            SceneManager.LoadScene("End Screen"); //changes the scene
            
        }
        
    }

    void EndScreenMenu()
    {
        if (highScores.Count == 0)  
        {
            if (File.Exists(PATH_HIGH_SCORE))
            {
                //get the high scores from the file as a string
                string fileContents = File.ReadAllText(PATH_HIGH_SCORE);
                //splits the string up into an array
                string[] fileSplit = fileContents.Split('\n');
                //goes through all the strings that are numbers
                for (int i = 1; i < fileSplit.Length - 1; i++)
                {
                    //add the number(converted from a string) to high scores
                    highScores.Add(Int32.Parse(fileSplit[i]));
                }
            }
            else
            {
                highScores.Add(0);
            }
            
            for (int i = 0; i < highScores.Count; i++)
            {
                if (highScores[i] < score)
                {
                    highScores.Insert(i, score);
                    break; //stops the loop so it is not infinite
                }
                //first one keeps track of how long it goes through the loop
                // second one stops the loop
                // 3rd one gets it out of the loop
            }

            if (highScores.Count > 5) //if we have more than 5 high scores
            {
                //cut the length to a total of 5
                highScores.RemoveRange(5,highScores.Count - 5);
            }
       
            string highScoreStr = "High Scores:\n";
            // makes a string out of the high scores picked out
            for (int i = 0; i < highScores.Count; i++)
            {
                highScoreStr += highScores[i] + "\n";
            }

            displayText.text = highScoreStr; //changes display to the high scores

            File.WriteAllText(PATH_HIGH_SCORE, highScoreStr); //copies it to the highscore file
        }
        
    }
}
