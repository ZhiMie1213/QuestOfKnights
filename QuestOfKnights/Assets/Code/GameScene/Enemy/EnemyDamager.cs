using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public float lifeTime;
    //public float growSpeed;
    private Vector3 targeSize;

    public bool shouldKnocBack;

    public bool destroyParint;

    public bool damageOverTime;
    public bool timeBetweenDamage;
    private float damageCounter;

    private List<EnemyController> enemiesInRange = new List<EnemyController>( );

    void Start( )
    {
        //targeSize = transform.localScale;
        //transform.localScale = Vector3.zero;
    }

    void Update( )
    {
        //武器が少しつづ大きくなって出現する
        /*transform.localScale = Vector3.MoveTowards( transform.localScale, targeSize, 
            growSpeed * Time.deltaTime );*/

        lifeTime -= Time.deltaTime;
        //武器の出現時間が終わったら消える
        if ( lifeTime <= 0 )
        {
            //targeSize = Vector3.zero;

            if ( transform.localScale.x == 0f )
            {
                Destroy(gameObject);

                if ( destroyParint )
                {
                    Destroy( transform.parent.gameObject );
                }
            }
        }
    }

    //敵にダメージを与える
    private void OnTriggerEnter2D( Collider2D collision )
	{
        if ( damageOverTime == false )
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnocBack);
            }
        }
        else
        {
            if ( collision.tag == "Enemy" )
            {
                enemiesInRange.Add( collision.GetComponent<EnemyController>( ) );
            }
        }
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        if ( damageOverTime == true )
        {
            if ( collision.tag == "Enemy" )
            {
                enemiesInRange.Remove( collision.GetComponent<EnemyController>( ) );
            }
        }
    }
}
