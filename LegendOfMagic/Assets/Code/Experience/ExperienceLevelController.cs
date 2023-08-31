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

    void Start ( )
    {
        
    }

    void Update(  )
    {
        
    }

    //プレイヤーがもらった経験玉の数を表示する
    public void GetExp( int amountToGet )
    {
        currentExperience += amountToGet;
    }

    public void SpawnExp( Vector3 position, int exValue )
    {
        Instantiate( pickup, position, Quaternion.identity ).expValue = exValue;
    }
}
