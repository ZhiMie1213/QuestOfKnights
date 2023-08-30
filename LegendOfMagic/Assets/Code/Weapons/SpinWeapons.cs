using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapons : MonoBehaviour
{
    public float rotateSpeed;

    public Transform holder;

    void Start( )
    {
        
    }

    void Update( )
    {
        //剣がプレイヤーの周りに360度で回す。
		holder.rotation = Quaternion.Euler( 0f, 0f, holder.rotation.eulerAngles.z - ( rotateSpeed * Time.deltaTime ) );
    }
}
