using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private void Awake( )
    {
        instance = this;
    }

    public float currentHealth, maxHealth;

    public Slider healthSlider;

    public GameObject deathEffect;

    public EnemyController enemyController;
    
    [SerializeField]
    private float damageTime;
    [SerializeField]
    private float fiashTime;

    private SpriteRenderer spriteRenderer;

    void Start( )
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        
        spriteRenderer = GetComponent<SpriteRenderer>( );
    }

    void Update( )
    {
        
    }

    public void TakeDamage( float damageToTake )
    {
        currentHealth -= damageToTake;
        
        //プレイヤーのHPが０になったらプレイヤーが消す
        if ( currentHealth <= 0 )
        {
            gameObject.SetActive( false );

            levelManger.instance.EndLevel( );
            //死んだ時の表現
            Instantiate( deathEffect, transform.position, transform.rotation );
            
            SFXManager.instance.PlaySFX( 3 );
        }
        healthSlider.value = currentHealth;
        
        gameObject.layer = LayerMask.NameToLayer( "PlayerDamage" );
        StartCoroutine( Damage( ) );
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
        gameObject.layer = LayerMask.NameToLayer( "Default" );
    }
}
