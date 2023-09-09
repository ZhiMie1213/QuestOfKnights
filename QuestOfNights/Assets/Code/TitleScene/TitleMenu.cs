using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    private bool oneshotSfx;
    
    void Update()
    {
        if ( Input.anyKey )
        {
            if ( !oneshotSfx )
            {
                Invoke( "LoadScene", 0.2f );
                oneshotSfx = true;
            }
        }
    }

    void LoadScene ( )
    {
        Application.LoadLevel("Game Scene");
    }
}
