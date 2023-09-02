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
    void Start( )
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
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
        }

        healthSlider.value = currentHealth;
    }
}
