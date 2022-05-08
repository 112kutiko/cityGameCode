using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTutorial : MonoBehaviour
{
    public GameObject tutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
        main_game_controler.controls.PauseGame();
        if (PlayerPrefs.HasKey("tuto"))
        {
            if (PlayerPrefs.GetInt("tuto") == 1)
            {/// skip tutorial
                main_game_controler.controls.ResumeGame();
                tutorialPanel.SetActive(false);
            }
            else
            {// not skip
                main_game_controler.controls.shop_btn.SetActive(false);
                main_game_controler.controls.start_btn.SetActive(false);
            }
        }
        else
        {// first time

            PlayerPrefs.SetInt("tuto", 0); 
            tutorialPanel.SetActive(true);
            main_game_controler.controls.shop_btn.SetActive(false);
            main_game_controler.controls.start_btn.SetActive(false); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skipNoSave()
    {
        PlayerPrefs.SetInt("tuto", 0);
    }

    public void skipSave()
    {
        PlayerPrefs.SetInt("tuto", 1);
    }



}
