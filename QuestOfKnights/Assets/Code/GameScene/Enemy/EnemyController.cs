using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    private Transform target;

    public float hitWaitTime = 1f;
    private float hitCounter;

    public float damage;

    public float health = 5f;

    public float knockBackTime = .5f;
    private float knockBackCounter;

    public int expToGive = 1;

    void Start( )
    {
        target = PlayerHealthController.instance.transform;
    }

    void Update( )
    {
        //敵がプレイヤーの攻撃を受けると、敵は吹っ飛ぶ
        if ( knockBackCounter > 0 )
        {
            knockBackCounter -= Time.deltaTime;

            if ( moveSpeed > 0 )
            {
                moveSpeed = -moveSpeed * 2f;
            }

            if ( knockBackCounter <= 0 )
            {
                moveSpeed = Math.Abs( moveSpeed * .5f );
            }
        }
        
        // 敵が自動的にプレイヤーの方面に向かって行く
        theRB.velocity = ( target.position - transform.position ).normalized * moveSpeed;
        
        if ( hitCounter > 0f )
        {
            hitCounter -= Time.deltaTime;
        }
    }

    //プレイヤーにダメージを与える
    private void OnCollisionEnter2D( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Player" && hitCounter <= 0f )
        {
            PlayerHealthController.instance.TakeDamage( damage );

            hitCounter = hitWaitTime;
        }
    }
    
    //敵のHPが０になったら消えて、現在の位置に経験玉を生成する
    public void TakeDamage( float damageToTake)
    {
        health -= damageToTake;
        if ( health <= 0 )
        {
            Destroy( gameObject );
            
            ExperienceLevelController.instance.SpawnExp( transform.position, expToGive );
            
            SFXManager.instance.PlayerSFXPitched( 0 );
        }
        /*else
        {
            SFXManager.instance.PlayerSFXPitched( 1 );
        }*/
        
        DamageNumberController.instance.SpawnDamage( damageToTake, transform.position );
    }

    public void TakeDamage( float damageToTake, bool shouldKnockBack )
    {
        TakeDamage( damageToTake );

        if ( shouldKnockBack == true )
        {
            knockBackCounter = knockBackTime;
        }
    }
}
