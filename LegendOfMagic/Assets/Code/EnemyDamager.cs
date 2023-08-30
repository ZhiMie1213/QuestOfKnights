using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    void Start( )
    {
        
    }

    void Update( )
    {
        
    }

	private void OnTriggerEnter2D( Collider2D collision )
	{ 
		if ( collision.tag == "Enemy" )
        {
            collision.GetComponent<EnemyController>( ).TakeDamage( damageAmount );
        }
	}
}
