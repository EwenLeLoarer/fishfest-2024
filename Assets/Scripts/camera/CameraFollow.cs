using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using Unity.Collections;
using UnityEditor.iOS;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    private Transform tempPos = null;
    public float distanceFromPlayer = 5;
    public float height = 2;

    void Update()
    {
        if(Player != null && Player.transform != null)
            tempPos = Player.transform;
        if(tempPos != null){
            transform.position = tempPos.position - tempPos.forward * distanceFromPlayer;
            //transform.LookAt(Player.transform.position);
            transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
        }

    }
}
