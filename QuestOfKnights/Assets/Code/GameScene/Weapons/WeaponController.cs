using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject sword;
    void Update( )
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            sword.SetActive( false );
        }
    }
}
