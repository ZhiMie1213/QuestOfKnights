using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.XR;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public float lifeTime;
    public float growSpeed;
    private Vector3 targeSize;

    public bool shouldKnocBack;

    public bool damageOverTime;
    public float timeBetweenDamage;
    private float damageCounter;

    private List<EnemyController> enemiesInRange = new List<EnemyController>( );

    public bool destoryOnImpact;
    
    [SerializeField]
    private float damageTime;
    [SerializeField]
    private float fiashTime;

    private SpriteRenderer spriteRenderer;

    void Start( )
    {
        Destroy( gameObject, lifeTime );

        //targeSize = transform.localScale;
        //transform.localScale = Vector3.zero;
    }

    void Update( )
    {
        //武器が少しつづ大きくなって出現する
        //transform.localScale = Vector3.MoveTowards(transform.localScale, targeSize,
        //    growSpeed * Time.deltaTime);

        //lifeTime -= Time.deltaTime;
        //武器の出現時間が終わったら消える
        /*if (lifeTime <= 0)
        {
            targeSize = Vector3.zero;

            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject);

                if (destroyParint)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }*/

        if ( damageOverTime == true )
        {
            damageCounter -= Time.deltaTime;

            if( damageCounter <= 0 )
            {
                damageCounter = timeBetweenDamage;

                for ( int i = 0; i < enemiesInRange.Count; i++ )
                {
                    if ( enemiesInRange[ i ] != null )
                    {
                        enemiesInRange[ i ].TakeDamage( damageAmount, shouldKnocBack );
                    } else
                    {
                        enemiesInRange.RemoveAt( i );
                        i--;
                    }   
                }
            }
        }
    }

    //敵にダメージを与える
    private void OnTriggerEnter2D( Collider2D collision )
	{
        if ( damageOverTime == false )
        {
            if ( collision.tag == "Enemy" )
            {
                collision.GetComponent<EnemyController>( ).TakeDamage( damageAmount, shouldKnocBack );

                if ( destoryOnImpact )
                {
                    Destroy( gameObject );
                }
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
                StartCoroutine( Damage( ) );

            }
        }
    }
    
    IEnumerator Damage( )
    {
        Color color = spriteRenderer.color;
        for ( int i = 0; i < damageTime; i++ )
        {
            yield return new WaitForSeconds( fiashTime );
            spriteRenderer.color = new Color( color.r, color.g, color.b, 0.0f );

            yield return new WaitForSeconds( fiashTime );
            spriteRenderer.color = new Color( color.r, color.g, color.b, 1.0f );
        }
        spriteRenderer.color = color;
    }
}
