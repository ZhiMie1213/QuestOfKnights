using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : Weapon
{
    public EnemyDamager damager;

    private float attackCounter;
    
    void Start( )
    {
        SetStats( );
    }

    void Update( )
    {
        if ( statsUpdated == true )
        {
            statsUpdated = false;

            SetStats( );
        }

        attackCounter -= Time.deltaTime;
        if ( attackCounter <= 0 )
        {
            attackCounter = stats[ weaponLevel ].timeBetweenAttacks;

            if ( Input.GetAxisRaw( "Horizontal" ) != 0 )
            {
                if ( Input.GetAxisRaw( "Horizontal" ) > 0 )
                {
                    damager.transform.rotation = Quaternion.identity;
                }
                else
                {
                    damager.transform.rotation = Quaternion.Euler( 0f, 0f, 180f ); 
                }
            }
            
            Instantiate( damager, damager.transform.position, damager.transform.rotation, transform )
                .gameObject.SetActive( true );
        }
    }

    void SetStats ( )
    {
        damager.damageAmount = stats[ weaponLevel ].damage;
        
        damager.lifeTime = stats[ weaponLevel ].duration;

        damager.transform.localScale = Vector3.one * stats[ weaponLevel ].range;

        //attackCounter = 0f;
    }
}
