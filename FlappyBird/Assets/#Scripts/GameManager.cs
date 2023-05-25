using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public Obj obj;
    public ScoreManager scoreManager;

    public Text bestui;
    public Text scoreText;
    public int newScore;
    public int bestScore;

    public Text text1;
    public Text text2;
    public GameObject bgScore;

    public GameObject gameoverUI;


    void Start()
    {
        instance = this;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        newScore = instance.scoreManager.score;
        if(instance.player.isDead ==true)
        {
            OnPlayerDead();
        }
        if (Input.GetMouseButtonDown(0) && instance.player.isDead == true)
        {
            SceneManager.LoadScene("MainScene");
        }


        

    }

    public void OnPlayerDead()
    {
        if (bestScore == 0 || newScore > bestScore)
        {
            bestScore = newScore;
            PlayerPrefs.SetInt("BestRecord", bestScore);
        }
        gameoverUI.SetActive(true);
        bgScore.SetActive(true);
        text1.text = "" + GameManager.instance.newScore;
        text2.text = "" + GameManager.instance.bestScore;
        for(int i =0; i< GameManager.instance.scoreManager.digitImages.Length;i++)
        {
            GameManager.instance.scoreManager.digitImages[i].enabled = false;
        }
        
       


    }
    public void Init()
    {

        bestScore = PlayerPrefs.GetInt("BestRecord", bestScore);




    }
}
