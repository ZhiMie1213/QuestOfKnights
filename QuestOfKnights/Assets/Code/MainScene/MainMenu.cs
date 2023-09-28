using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioClip sfxButton;
    private bool oneshotSfx;
    
    void Update( )
    {
        if ( Input.anyKey )
        {
            if ( !oneshotSfx )
            {
                AudioSource.PlayClipAtPoint( sfxButton, Vector3.zero );
                Invoke("LoadScene", 0.3f);
                oneshotSfx = true;
            }
        }
    }

    [System.Obsolete]
    void LoadScene ( )
    {
        Application.LoadLevel("Game Scene");
    }
}
