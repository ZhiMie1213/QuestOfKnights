using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    void Start( )
    {
        target = FindObjectOfType<PlayerController>( ).transform;
    }

    void LateUpdate( )
    {
        //プレイヤーの座標に追跡する
        transform.position = new Vector3( target.position.x, target.position.y, transform.position.z );
    }
}
