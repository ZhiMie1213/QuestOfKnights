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
        //角度に変換する
        float angle = Mathf.Atan2( forward.x, forward.y ) * Mathf.Rad2Deg;
        //角度を代入
        transform.rotation = Quaternion.Euler( 0, 0, angle );
    }

    void Update( )
    {
        //武器の数値をアップ
        if (statsUpdated == true)
        {
            statsUpdated = false;

            SetStats();
        }
    }

    void SetStats()
    {
        //攻撃力
        damager.damageAmount = stats[weaponLevel].damage;
        //生成の間隔時間
        timeBetweenSpawn = stats[weaponLevel].timeBetweenAttacks;


    }
}
