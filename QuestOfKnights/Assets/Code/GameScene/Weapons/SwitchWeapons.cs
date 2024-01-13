using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    private PlayerController weaponList;

    private void Update( )
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            NextWeapon( );
        }
    }

    private void NextWeapon( )
    {
        //weaponList.assignedWeapons.Count++;
    }
}
