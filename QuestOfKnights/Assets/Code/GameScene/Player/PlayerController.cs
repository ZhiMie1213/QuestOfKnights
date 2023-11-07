using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake( )
    {
        instance = this;
    }
    
    public float moveSpeed;

    public float pickUpRange = 1.5f;

    public Weapon activeWeapon;

    public List<Weapon> unassignedWeapons, assignedWeapons;

    public int maxWeapon = 3;

    [ HideInInspector ]
    public List <Weapon> fullyLevelledWeapons = new List<Weapon>( );
    
    void Start( )
    {
        if ( assignedWeapons.Count == 0 )
        {
            AddWeapon( Random.Range( 0, unassignedWeapons.Count ) );
        }
    }

    void Update( )
    {
        //プレイヤーの操作
        Vector3 moveInput = new Vector3( 0f, 0f, 0f );
        moveInput.x = Input.GetAxisRaw( "Horizontal" );
        moveInput.y = Input.GetAxisRaw( "Vertical" );
        moveInput.Normalize( );

        //プレイヤーの速度
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }

    public void AddWeapon ( int weaponNumber )
    {
        if ( weaponNumber < unassignedWeapons.Count )
        {
            assignedWeapons.Add( unassignedWeapons[ weaponNumber ] );

            unassignedWeapons[ weaponNumber ].gameObject.SetActive( true );
            unassignedWeapons.RemoveAt( weaponNumber );
        }
    }

    public void AddWeapon( Weapon weaponToAdd ) 
    {
        weaponToAdd.gameObject.SetActive( true );

        assignedWeapons.Add( weaponToAdd );
        unassignedWeapons.Remove( weaponToAdd );
    }
}