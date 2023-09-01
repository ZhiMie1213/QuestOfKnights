using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapons : Weapon
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
        //武器がプレイヤーの周りに360度で回す（武器の回転速度）
        holder.rotation = Quaternion.Euler( 0f, 0f, 
            holder.rotation.eulerAngles.z - ( rotateSpeed * Time.deltaTime * stats[ weaponLevel ].speed ) );

        spawnCounter -= Time.deltaTime;
        //前の武器の出現時間が終わったら新しいの武器が生成する
        if ( spawnCounter <= 0 )
        {
            spawnCounter = timeBetweenSpawn;

            Instantiate( daggerToSpawn, daggerToSpawn.position, daggerToSpawn.rotation, holder ).gameObject.SetActive( true );
        }
    }

    //武器の数値
    public void SetStats( )
    {
        //攻撃力
        damager.damageAmount = stats[weaponLevel].damage;
        //大きさ
        transform.localScale = Vector3.one * stats[ weaponLevel ].range;
        //生成の間隔時間
        timeBetweenSpawn = stats[ weaponLevel ].timeBetweenAttacks;
        //持たせる時間
        damager.lifeTime = stats[ weaponLevel ].duration;
        
        spawnCounter = 0f;
    }
}
