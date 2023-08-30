using System;
using System.Collections;
using System.Collections.Generic;
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

    void Start( )
    {
        target = PlayerHealthController.instance.transform;
    }

    void Update( )
    {
        // 敵が自動的にプレイヤーの方面に向かって行く
        theRB.velocity = ( target.position - transform.position ).normalized * moveSpeed;
        
        if ( hitCounter > 0f )
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if ( collision.gameObject.tag == "Player" && hitCounter <= 0f )
        {
            PlayerHealthController.instance.TakeDamage( damage );

            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage( float damageToTake)
    {
        health -= damageToTake;

        if ( health <= 0 )
        {
            Destroy( gameObject );
        }
    }
}
