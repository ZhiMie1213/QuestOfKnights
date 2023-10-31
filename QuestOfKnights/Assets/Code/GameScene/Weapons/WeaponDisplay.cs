using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    void Update( )
    {
        if ( Input.GetKeyDown(KeyCode.Space ) )
        {
            sword.SetActive( true );
        }
    }
}
