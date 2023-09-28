using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    public void Awake()
    {
        instance = this;
    }

    public DamageNumber numberToSpawn;
    public Transform numberCanvas;

    private List<DamageNumber> numberPool = new List<DamageNumber>( );

    public void SpawnDamage ( float damageAmount, Vector3 location )
    {
        int rounded = Mathf.RoundToInt( damageAmount );

        DamageNumber newDamage = GetFromPool( );
        
        newDamage.Setup( rounded );
        newDamage.gameObject.SetActive( true );

        newDamage.transform.position = location;
    }

    public  DamageNumber GetFromPool( )
    {
        DamageNumber numberToQutput = null;

        if ( numberPool.Count == 0 )
        {
            numberToQutput = Instantiate( numberToSpawn, numberCanvas );
        }
        else
        {
            numberToQutput = numberPool[ 0 ];
            numberPool.RemoveAt( 0 );
        }

        return numberToQutput;
    }

    public void PlaceInPool ( DamageNumber numberToPlace )
    {
        numberToPlace.gameObject.SetActive( true );
        
        numberPool.Add( numberToPlace );
    }
}
