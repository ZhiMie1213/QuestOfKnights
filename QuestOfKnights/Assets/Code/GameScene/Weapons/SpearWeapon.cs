using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearWeapon : Weapon
{
    public EnemyDamager damager;

    private float attackCounter;
    private Vector3 targetSize;
    public float growSpeed = 5f;
    
    void Start( )
    {
        SetStats( );
        
        targetSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    void Update( )
    {
        transform.localScale = Vector3.MoveTowards( transform.localScale, targetSize,
            growSpeed * Time.deltaTime );
        
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
            
            SFXManager.instance.PlayerSFXPitched( 4 );
        }
        
        if ( statsUpdated == true )
        {
            statsUpdated = false;

            SetStats( );
        }
    }

    void SetStats ( )
    {
        damager.damageAmount = stats[ weaponLevel ].damage;
        
        damager.lifeTime = stats[ weaponLevel ].duration;

        damager.transform.localScale = Vector3.one * stats[ weaponLevel ].range;

        attackCounter = 0f;
    }
}
