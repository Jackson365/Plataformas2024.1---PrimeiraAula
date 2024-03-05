 using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text coinText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Splash");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
        SceneManager.LoadScene("GUI", LoadSceneMode.Additive);
    }
    
    public void UpdateLives(int value)
    {
        coinText.text = "x "  + value.ToString();
    }
}
