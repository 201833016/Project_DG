using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "Monster" && !other.CompareTag("Maps"))
        {
            // player, 몬스터, Map를 제외한 나머지만 지우게 하기
            Destroy(other.gameObject);  
        }
          
    }
}
