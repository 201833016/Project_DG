using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMove : MonoBehaviour
{
    
    [SerializeField] private GameObject player; //square로 변경하기
    [SerializeField] private float offsetX = 0;
    [SerializeField] private float offsetY = 0;
    [SerializeField] private float offsetZ = -10;

    Vector3 cameraPosition;
    
    private void LateUpdate() 
    {
        cameraPosition.x = player.transform.position.x + offsetX; 
        cameraPosition.y = player.transform.position.y + offsetY; 
        cameraPosition.z = player.transform.position.z + offsetZ;   

        transform.position = cameraPosition;
    }
    
}
