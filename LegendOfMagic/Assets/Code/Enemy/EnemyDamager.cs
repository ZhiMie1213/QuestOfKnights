using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public float lifeTime, growSpeed = 5f;
    private Vector3 targeSize;

    public bool shouldKnocBack;

    void Start( )
    {
        targeSize = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    void Update( )
    {
        //武器が少しつづ大きくなって出現する
        transform.localScale = Vector3.MoveTowards( transform.localScale, targeSize, 
            growSpeed * Time.deltaTime );

        lifeTime -= Time.deltaTime;
        //武器の出現時間が終わったらどんどん小さくなって消えていく
        if ( lifeTime <= 0 )
        {
            targeSize = Vector3.zero;

            if ( transform.localScale.x == 0f )
            {
                Destroy( gameObject );
            }
        }
    }

    //敵にダメージを与える
    private void OnTriggerEnter2D( Collider2D collision )
	{ 
		if ( collision.tag == "Enemy" )
        {
            collision.GetComponent<EnemyController>( ).TakeDamage( damageAmount, shouldKnocBack );
        }
	}
}
