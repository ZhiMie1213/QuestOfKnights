using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLevelController : MonoBehaviour
{
    public static ExperienceLevelController instance;
    private void Awake( )
    {
        instance = this;
    }
    
    public int currentExperience;

    public ExpPickup pickup;

    public List<int> expLevels;
    public int currentLevel = 1, levelCount = 100;

    public List<Weapon> weaponsToUpgrade;

    void Start ( )
    {
        while ( expLevels.Count < levelCount )
        {
            expLevels.Add( Mathf.CeilToInt( expLevels [ expLevels.Count - 1 ] * 1.1f ) );
        }
    }

    void Update(  )
    {
        
    }

    //プレイヤーがもらった経験玉の数を表示する
    public void GetExp( int amountToGet )
    {
        currentExperience += amountToGet;

        if ( currentExperience >= expLevels[ currentLevel ] )
        {
            LevelUp( );
        }
        UIController.instance.UpdateExperience( currentExperience, expLevels[ currentLevel ], 
            currentLevel );
        
        SFXManager.instance.PlayerSFXPitched( 2 );
    }

    public void SpawnExp( Vector3 position, int exValue )
    {
        Instantiate( pickup, position, Quaternion.identity ).expValue = exValue;
    }

    void LevelUp( )
    {
        currentExperience -= expLevels[ currentLevel ];
        
        currentLevel++;
        //設定したレベルの値を超えられない
        if ( currentLevel >= expLevels.Count )
        {
            currentLevel = expLevels.Count - 1;
        }
        
        UIController.instance.levelUpPanel.SetActive( true );
        Time.timeScale = 0f;

        weaponsToUpgrade.Clear( );

        List<Weapon> availabWeapons = new List<Weapon>( );
        availabWeapons.AddRange( PlayerController.instance.assignedWeapons );

        if( availabWeapons.Count > 0 )
        {
            int selected = UnityEngine.Random.Range( 0, availabWeapons.Count );
            weaponsToUpgrade.Add( availabWeapons[ selected ] );
            availabWeapons.RemoveAt( selected );
        }
        if ( PlayerController.instance.assignedWeapons.Count + PlayerController.instance.fullyLevelledWeapons.Count 
            < PlayerController.instance.maxWeapon ) 
        {
            availabWeapons.AddRange( PlayerController.instance.unassignedWeapons );
        }

        for( int i = weaponsToUpgrade.Count; i < 3; i++ )
        {
            if ( availabWeapons.Count > 0 )
            {
                int selected = UnityEngine.Random.Range( 0, availabWeapons.Count );
                weaponsToUpgrade.Add( availabWeapons[ selected ] );
                availabWeapons.RemoveAt( selected );
            }
        }

        for( int i = 0; i < weaponsToUpgrade.Count; i++ ) 
        {
            UIController.instance.levelUpButtons[ i ].UpdateButtonDisplay( weaponsToUpgrade[ i ] );
        }

        for ( int i = 0; i < UIController.instance.levelUpButtons.Length; i++ )
        {
            if ( i < weaponsToUpgrade.Count )
            {
                UIController.instance.levelUpButtons[ i ].gameObject.SetActive( true );
            }
            else
            {
                UIController.instance.levelUpButtons[ i ].gameObject.SetActive( false );
            }
        }

        SFXManager.instance.PlayerSFXPitched( 5 );
    }
}
