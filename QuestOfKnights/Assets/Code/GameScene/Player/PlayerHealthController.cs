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

    void Start( )
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    void Update( )
    {
        
    }

    //プレイヤーにダメージを与える
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && enemyController.hitCounter <= 0f)
        {
            PlayerHealthController.instance.TakeDamage(enemyController.damage);

            enemyController.hitCounter = enemyController.hitWaitTime;

            //gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
            //StartCoroutine(Damage());
        }
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
    }
}
