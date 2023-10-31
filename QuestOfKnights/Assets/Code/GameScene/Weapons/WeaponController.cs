using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    void Update( )
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            this.gameObject.SetActive( false );
        }
    }
}
