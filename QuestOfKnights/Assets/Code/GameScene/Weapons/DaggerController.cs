using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerController : Weapon
{
    public EnemyDamager damager;

    public float timeBetweenSpawn;

    void Start( )
    {
        //Šp“x‚É•ÏŠ·‚·‚é
        float angle = Mathf.Atan2( forward.x, forward.y ) * Mathf.Rad2Deg;
        //Šp“x‚ğ‘ã“ü
        transform.rotation = Quaternion.Euler( 0, 0, angle );
    }

    void Update( )
    {
        //•Ší‚Ì”’l‚ğƒAƒbƒv
        if (statsUpdated == true)
        {
            statsUpdated = false;

            SetStats();
        }
    }

    void SetStats()
    {
        //UŒ‚—Í
        damager.damageAmount = stats[weaponLevel].damage;
        //¶¬‚ÌŠÔŠuŠÔ
        timeBetweenSpawn = stats[weaponLevel].timeBetweenAttacks;


    }
}
