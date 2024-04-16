using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool isPaused;

    [SerializeField] private Text soundEffectsButton;
    [SerializeField] private GameObject soundGO;


    void Awake() 
    {
        this.isPaused = panel.activeSelf;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            this.isPaused = !this.isPaused;
            panel.SetActive(this.isPaused);
        }
    }

    public void Restart() 
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    
    }

    public void ToggleSoundEffects() 
    {
        if (PlayerPrefs.GetInt("soundEffects") == 1) 
        {
            PlayerPrefs.SetInt("soundEffects", 0);
            soundEffectsButton.text = "Sound Effects: Off";
        } 
        else 
        {
            PlayerPrefs.SetInt("soundEffects", 1);
            soundEffectsButton.text = "Sound Effects: On";
        }
        soundGO.SetActive(PlayerPrefs.GetInt("soundEffects") == 1);    
        
    }
}
