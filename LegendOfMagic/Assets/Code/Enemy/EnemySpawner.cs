using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float timeToSpawn;
    private float spawnCounter;
    private float despawnDistance;

    public GameObject enemyToSpawn;
    public Transform maxSapwn, minSapwn;
    private Transform target;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public int checkPerFrame;
    private int enemyToCheck;
    
    void Start( )
    {
        spawnCounter = timeToSpawn;
        target = PlayerHealthController.instance.transform;
        //敵の生成が重ならないように
        despawnDistance = Vector3.Distance( transform.position, maxSapwn.position ) + 4f;
    }

    void Update( )
    {
        spawnCounter -= Time.deltaTime;
        if ( spawnCounter <= 0 )
        {
            spawnCounter = timeToSpawn;
            
            //敵のObjectをチェックする
            GameObject newEnemy = Instantiate( enemyToSpawn, selectSpawnPoint( ), transform.rotation );
            spawnedEnemies.Add( newEnemy );
        }

        transform.position = target.position;

        int checkTraget = enemyToCheck + checkPerFrame;
        while ( enemyToCheck < checkTraget )
        {
            if ( enemyToCheck < spawnedEnemies.Count )
            {
                if ( spawnedEnemies[enemyToCheck] != null )
                {
                    if (Vector3.Distance( transform.position, spawnedEnemies[enemyToCheck].transform.position) >
                        despawnDistance )
                    {
                        Destroy( spawnedEnemies[enemyToCheck] );
                        
                        spawnedEnemies.RemoveAt( enemyToCheck );
                        checkTraget--;
                    }
                    else
                    {
                        enemyToCheck++;
                    }
                }
                else
                {
                    spawnedEnemies.RemoveAt(enemyToCheck);
                    checkTraget--;
                }
            }
            else
            {
                enemyToCheck = 0;
                checkTraget = 0;
            }
        }
    }

    public Vector3 selectSpawnPoint( )
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range( 0f, 1f ) > .5f;
        
        //メインカメラが映してないの周りに敵を生成する
        if ( spawnVerticalEdge )
        {
            spawnPoint.y = Random.Range( minSapwn.position.y, maxSapwn.position.y );
            if ( Random.Range( 0f, 1f ) > .5f) 
            {
                spawnPoint.x = maxSapwn.position.x;
            }
            else
            {
                spawnPoint.x = minSapwn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range( minSapwn.position.x, maxSapwn.position.x );
            if ( Random.Range( 0f, 1f ) > .5f )
            {
                spawnPoint.y = maxSapwn.position.y;
            }
            else
            {
                spawnPoint.y = minSapwn.position.y;
            } 
        }

        return spawnPoint;
    }
}
