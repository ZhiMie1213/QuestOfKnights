using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    private bool oneshotSfx;
    
    void Update()
    {
        if ( Input.GetKey( KeyCode.Space ) )
        {
            Invoke( "LoadScene", 0.2f );
        }
    }

    void LoadScene ( )
    {
        Application.LoadLevel("Game Scene");
    }
}
