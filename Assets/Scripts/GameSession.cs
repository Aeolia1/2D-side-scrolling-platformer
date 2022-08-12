using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    protected AudioSource deathAudio; //luo

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        deathAudio = GetComponent<AudioSource>(); //luo
        deathAudio.Play(); //luo
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
        DontDestroyOnLoad(gameObject);
        }
    }
        
    void Start()
    {
        livesText.text = playerLives.ToString();
    }


    public void ProcessPlayerDeath()
    {
        deathAudio = GetComponent<AudioSource>(); //luo
        deathAudio.Play(); //luo
        if (playerLives > 0)
        {
            TakeLife();
        }
        else
        {
            Reset0();
        } 
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }



    void Reset0()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
