using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManger : MonoBehaviour
{
    public static levelManger instance;

    private void Awake( )
    {
        instance = this;
    }

    private bool gameActive;
    public float timer;
    
    void Start( )
    {
        gameActive = true;
    }

    void Update( )
    {
        if ( gameActive == true )
        {
            timer += Time.deltaTime;
            UIController.instance.UpdateTimer( timer );
        }
    }

    public void EndLevel ( )
    {
        gameActive = false;

        //UIController.instance.levelEndScreen.SetActive( true );
    }
}
