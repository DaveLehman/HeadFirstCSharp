﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    // GameController Script -- all Game Objects in this game will be generated by scripts. We have a series
    // of prefabbed objects in the Prefabs folder we can call upon.

    /* Unity will only run scripts that are attached to GameObjects in a scene. The GameController script will
     * create instances of our OneBallPrefab, but we need to attach it to something. Luckily, we already know
     * that a Camera is just a GameObject with a Camera Component (and also an AudioListener). The Main
     * Camera will already be available in the scene
     */

    /* We've now implemented two Game Modes, so have to pay attention to what Mode we are in ---
     * Mode 1: Running. Balls being added to the scene, clicking on them makes them disappear
     *  and the score go up
     * Mode 2: Game Over. No new calls, clicking on them does nothing, Game Over banner displayed
     */

    public GameObject OneBallPrefab;
    public GameObject TwoBallPrefab;
    public GameObject ThreeBallPrefab;
    public GameObject FourBallPrefab;
    public GameObject FiveBallPrefab;
    public GameObject SixBallPrefab;
    public GameObject SevenBallPrefab;
    public GameObject EightBallPrefab;
    public GameObject NineBallPrefab;
    public GameObject TenBallPrefab;
    public GameObject ElevenBallPrefab;
    public GameObject TwelveBallPrefab;
    public GameObject ThirteenBallPrefab;
    public GameObject FourteenBallPrefab;
    public GameObject FifteenBallPrefab;

    public int Score = 0;

    public bool GameOver = true;
    public int NumberOfBalls = 0;
    public int MaximumBalls = 15;

    public Text ScoreText;
    public Button PlayAgainButton;



    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating is a method available in any GameObject script
        InvokeRepeating("AddABall", 1.5F, 1);
    }

    void AddABall()
    {
        if(!GameOver)
        {
            // Instantiate is a method available in any GameObject script
            //Instantiate(OneBallPrefab);

            
            int whichBall = Random.Range(1, 16);
            switch(whichBall)
            {
                case 1:
                    Instantiate(OneBallPrefab);
                    break;
                case 2:
                    Instantiate(TwoBallPrefab);
                    break;
                case 3:
                    Instantiate(ThreeBallPrefab);
                    break;
                case 4:
                    Instantiate(FourBallPrefab);
                    break;
                case 5:
                    Instantiate(FiveBallPrefab);
                    break;
                case 6:
                    Instantiate(SixBallPrefab);
                    break;
                case 7:
                    Instantiate(SevenBallPrefab);
                    break;
                case 8:
                    Instantiate(EightBallPrefab);
                    break;
                case 9:
                    Instantiate(NineBallPrefab);
                    break;
                case 10:
                    Instantiate(TenBallPrefab);
                    break;
                case 11:
                    Instantiate(ElevenBallPrefab);
                    break;
                case 12:
                    Instantiate(TwelveBallPrefab);
                    break;
                case 13:
                    Instantiate(ThirteenBallPrefab);
                    break;
                case 14:
                    Instantiate(FourteenBallPrefab);
                    break;
                case 15:
                    Instantiate(FifteenBallPrefab);
                    break;
                default:
                    throw new System.Exception("Ball instantiation problem");
                    break;
            }
            
            NumberOfBalls++;
            if(NumberOfBalls >= MaximumBalls)
            {
                GameOver = true;
                PlayAgainButton.gameObject.SetActive(true);
            }
        }

    }

    public void ClickedOnBall()
    {
        Score++;
        NumberOfBalls--;
    }

    public void StartGame()
    {
        // this is what's in the book. It doesn't work. Following does
        // foreach (GameObject ball in GameObject.FindGameObjectsWithTag("GameController"))
        // {
          // Destroy(ball);   
        //}
        // THIS does work -- book had us go add a 'tag' to the Prefab object in Unity
        foreach(GameObject ball in GameObject.FindGameObjectsWithTag("ball"))
        {
            Destroy(ball);
        }
        PlayAgainButton.gameObject.SetActive(false);
        Score = 0;
        NumberOfBalls = 0;
        GameOver = false;
    }


    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
    }
}
