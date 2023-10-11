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
        //�p�x�ɕϊ�����
        float angle = Mathf.Atan2( forward.x, forward.y ) * Mathf.Rad2Deg;
        //�p�x����
        transform.rotation = Quaternion.Euler( 0, 0, angle );
    }

    void Update( )
    {
        //����̐��l���A�b�v
        if (statsUpdated == true)
        {
            statsUpdated = false;

            SetStats();
        }
    }

    void SetStats()
    {
        //�U����
        damager.damageAmount = stats[weaponLevel].damage;
        //�����̊Ԋu����
        timeBetweenSpawn = stats[weaponLevel].timeBetweenAttacks;


    }
}
