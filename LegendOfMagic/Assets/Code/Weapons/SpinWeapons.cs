using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapons : MonoBehaviour
{
    public float rotateSpeed;

    public Transform holder, daggerToSpawn;

    public float timeBetweenSpawn;
    private float spawnCounter;
    
    void Start( )
    {
        
    }

    void Update( )
    {
        //武器がプレイヤーの周りに360度で回す
		holder.rotation = Quaternion.Euler( 0f, 0f, holder.rotation.eulerAngles.z - ( rotateSpeed * Time.deltaTime ) );

        spawnCounter -= Time.deltaTime;
        if ( spawnCounter <= 0 )
        {
            spawnCounter = timeBetweenSpawn;

            Instantiate( daggerToSpawn, daggerToSpawn.position, daggerToSpawn.rotation, holder ).gameObject.SetActive( true );
        }
    }
}
