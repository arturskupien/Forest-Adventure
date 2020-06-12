using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject sound;

    GameObject[] backgroundSounds;

    public static int pickedGems = 0;
    public static int lifes = 3;


    void Awake()
    {
        backgroundSounds = GameObject.FindGameObjectsWithTag("BackgroundSound");
    }

    void Update()
    {
        if (backgroundSounds.Length > 1)
        {
            Object.Destroy(backgroundSounds[1]);
        }
    }


    void MakeThisTheOnlyGameManager()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else
        {
            if (GM != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ChangeLevel(string functionality)
    {
        if (functionality == "retry") // works both for retry and play button, I just made retry button 1st
        {
            SceneManager.LoadScene(1);
            lifes = 3;
            pickedGems = 0;
        }
        else if (functionality == "menu")
        {
            SceneManager.LoadScene(0);
            lifes = 3;
            pickedGems = 0;
        }
        else if (functionality == "quit")
        {
            Application.Quit();
        }
    }
}
