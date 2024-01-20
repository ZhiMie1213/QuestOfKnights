using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    private PlayerController weaponList;
    private int nIndex = 0;

    private void Awake( )
    {
        weaponList = Resources.Load<PlayerController>(typeof(PlayerController).Name);
    }

    private void Update( )
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            NextWeapon( );
        }
    }

    private void NextWeapon( )
    {
        nIndex++;
        
        if ( nIndex == weaponList.assignedWeapons.Count )
        {
            
        }
    }
}
