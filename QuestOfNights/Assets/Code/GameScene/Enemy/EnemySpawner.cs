using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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

    public List<WaveInfo> waves;

    private int currentWave;

    private float waveCounter;

    void Start( )
    {
        target = PlayerHealthController.instance.transform;
        //敵の生成が重ならないように
        despawnDistance = Vector3.Distance( transform.position, maxSapwn.position ) + 4f;

        currentWave -= 1;
        GoToNextWave( );
    }

    void Update( )
    {
        //敵が順番によって生成する
        if ( PlayerHealthController.instance.gameObject.activeSelf )
        {
            if ( currentWave < waves.Count )
            {
                waveCounter -= Time.deltaTime;
                if ( waveCounter <= 0 )
                {
                    GoToNextWave( );
                }

                spawnCounter -= Time.deltaTime;
                if ( spawnCounter <= 0 )
                {
                    spawnCounter = waves[ currentWave ].timeBetweenSpawns;

                    GameObject newEnemy = Instantiate( waves[ currentWave ]. enemyToSpawn, selectSpawnPoint(), 
                        Quaternion.identity  );
                    spawnedEnemies.Add( newEnemy );
                }
            }
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
                        Destroy( spawnedEnemies[ enemyToCheck ] );
                        
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
                    spawnedEnemies.RemoveAt( enemyToCheck );
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

    public void GoToNextWave ( )
    {
        currentWave++;

        if ( currentWave >= waves.Count )
        {
            currentWave = waves.Count - 1;
        }
        waveCounter = waves[ currentWave ].waveLemght;
        spawnCounter = waves[ currentWave ].timeBetweenSpawns;
    }
}

[System.Serializable]
public class WaveInfo
{
    public GameObject enemyToSpawn;
    public float waveLemght = 10f;
    public float timeBetweenSpawns = 1f;
    
}
