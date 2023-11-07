using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake( )
    {
        instance = this;
    }

    public Slider explvlSlider;
    public TMP_Text expLvlText;

    public TMP_Text timeText;

    public GameObject levelEndScreen;

    public LevelUpSelectionButton[ ] levelUpButtons;
    public GameObject levelUpPanel;

    public string mainMenuName;

    public GameObject pauseScreen;

    void Start( )
    {

    }

    void Update( )
    {
        if ( Input.GetKeyDown(KeyCode.Escape ) )
        {
            PauseUnpause( );
        }
    }

    public void UpdateExperience( int currentExp, int levelExp, int currentLvl )
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;

        expLvlText.text = "Lv: " + currentLvl;
    }

    public void UpdateTimer( float time )
    {
        float minutes = Mathf.FloorToInt( time / 60f );
        float seconds = Mathf.FloorToInt( time % 60 );

        timeText.text = minutes + ":" + seconds.ToString( "00" );
    }

    public void GoToMainMenu( )
    {
        SceneManager.LoadScene( mainMenuName );
        Time.timeScale = 1f;
    }

    public void Restart( )
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene( ).name );
        Time.timeScale = 1f;
    }

    public void QuitGame( )
    {
        Application.Quit( );
    }

    public void PauseUnpause( )
    {
        if ( pauseScreen.activeSelf == false )
        {
            pauseScreen.SetActive( true );
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive( false );
            if ( pauseScreen.activeSelf == false )
            {
                Time.timeScale = 1f;
            }
        }
    }

    public void SkipLevelUp( )
    {
        levelUpPanel.SetActive( false );
        Time.timeScale = 1f;
    }
}
