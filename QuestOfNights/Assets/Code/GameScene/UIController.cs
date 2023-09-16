using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    private void Awake ( )
    {
        instance = this;
    }

    public Slider explvlSlider;
    public TMP_Text expLvlText;
    public TMP_Text timeText;

    public string titleMenuName;
    
    void Start ( )
    {
        
    }

    void Update ( )
    {
        
    }

    public void UpdateExperience ( int currentExp, int levelExp, int currentLvl )
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;
        
        expLvlText.text = "Lv: " + currentLvl;
    }

    public void UpdateTimer ( float time )
    {
        float minutes = Mathf.FloorToInt( time / 60f );
        float seconds = Mathf.FloorToInt( time % 60 );

        timeText.text = minutes + ":" + seconds.ToString( "00" );
    }

    public void GoToTitleMenu ( )
    {
        SceneManager.LoadScene( titleMenuName );
    }
}