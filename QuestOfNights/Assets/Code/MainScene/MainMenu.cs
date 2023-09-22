using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private bool oneshotSfx;
    
    void Update()
    {
        if ( Input.anyKey )
        {
            Invoke( "LoadScene", 0.2f );
        }
    }

    [System.Obsolete]
    void LoadScene ( )
    {
        Application.LoadLevel("Game Scene");
    }
}
