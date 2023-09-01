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
        
        PlayerController.instance.activeWeapon.LevelUp( );
    }
}
