﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeCount;
    public static int coinCount;

    private void Awake()
    {
        cameraScript = Camera.main.GetComponent<CameraScript>();
    }


    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
        countScore = true;
    }

    private void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                GameplayController.instance.SetScore(scoreCount);
                scoreCount++;
                
            }
            previousPosition = transform.position;
            
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;

            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetCoinScore(coinCount);
            
            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag ==  "Life")
        {
            lifeCount++;
            scoreCount += 300;
            GameplayController.instance.SetScore(scoreCount);
            GameplayController.instance.SetLifeScore(lifeCount);            

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Bounds")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            transform.position = new Vector3(500, 500, 0);
            lifeCount--;

            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);

        }

        if (target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            transform.position = new Vector3(500, 500, 0);
            lifeCount--;

            GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
        }
    }
}