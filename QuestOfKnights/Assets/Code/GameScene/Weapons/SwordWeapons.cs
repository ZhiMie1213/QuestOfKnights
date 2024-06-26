using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordWeapons : Weapon
{
    public float rotateSpeed;

    public Transform holder, daggerToSpawn;

    public float timeBetweenSpawn;
    private float spawnCounter;
    
    public EnemyDamager damager;

    void Start( )
    {
        SetStats( );
    }

    void Update( )
    {
        //設定した値で武器をプレイヤーの周りに回す（武器の回転速度）
        holder.rotation = Quaternion.Euler( 0f, 0f, 
            holder.rotation.eulerAngles.z - ( rotateSpeed * Time.deltaTime * stats[ weaponLevel ].speed ) );

        spawnCounter -= Time.deltaTime;
        //設定した再生の時間になったら新しいの武器が生成する
        if ( spawnCounter <= 0f )
        {
            spawnCounter = timeBetweenSpawn;
            //向かっている方向によって斬撃の方向を変える
            //X座標
            if (Input.GetAxisRaw( "Horizontal" ) != 0 )
            {
                if (Input.GetAxisRaw( "Horizontal" ) > 0 )
                {
                    damager.transform.rotation = Quaternion.identity;
                }
                else
                {
                    damager.transform.rotation = Quaternion.Euler( 0f, 0f, 180f );
                }
            }
            //Y座標
            if (Input.GetAxisRaw( "Vertical" ) != 0 )
            {
                if (Input.GetAxisRaw( "Vertical" ) > 0 )
                {
                    damager.transform.rotation = Quaternion.Euler( 0f, 0f, 90f );
                }
                if (Input.GetAxisRaw( "Vertical" ) < 0 )
                {
                    damager.transform.rotation = Quaternion.Euler( 0f, 0f, -90f );
                }

            }
            Instantiate( daggerToSpawn, daggerToSpawn.position, daggerToSpawn.rotation, holder )
                .gameObject.SetActive( true );

            SFXManager.instance.PlayerSFXPitched( 4 );
        }

        if ( statsUpdated == true )
        {
            statsUpdated = false;
            
            SetStats( );
        }
    }

    //武器の数値
    public void SetStats( )
    {
        //攻撃力
        damager.damageAmount = stats[ weaponLevel ].damage;
        //大きさ
        transform.localScale = Vector3.one * stats[ weaponLevel ].range;
        //生成の間隔時間
        timeBetweenSpawn = stats[ weaponLevel ].timeBetweenAttacks;
        //持たせる時間
        damager.lifeTime = stats[ weaponLevel ].duration;
    }
}
