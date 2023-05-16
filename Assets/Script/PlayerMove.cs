using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    private Vector2 speedVec;
    void Update()
    {
        speedVec = Vector2.zero;
        if(Input.GetKey(KeyCode.W))
        {
            speedVec.y += speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            speedVec.x -= speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            speedVec.y -= speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            speedVec.x += speed;
        }

        GetComponent<Rigidbody2D>().velocity = speedVec;
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        // 방이동을 위한 Teleport
        if(other.CompareTag("TPT"))
            {
                Vector3 TPposition = this.transform.position;
                this.transform.position = new Vector3(TPposition.x, TPposition.y + 5f, TPposition.z);
                Debug.Log("Move : Top");
            }
            else if(other.CompareTag("TPB"))
            {
                Vector3 TPposition = this.transform.position;
                this.transform.position = new Vector3(TPposition.x, TPposition.y - 5f, TPposition.z);
                Debug.Log("Move : Bottom"); 
            }
            else if(other.CompareTag("TPL"))
            {
                Vector3 TPposition = this.transform.position;
                this.transform.position = new Vector3(TPposition.x - 5f, TPposition.y, TPposition.z);
                Debug.Log("Move : Left"); 
            }
            else if(other.CompareTag("TPR"))
            {
                Vector3 TPposition = this.transform.position;
                this.transform.position = new Vector3(TPposition.x + 5f, TPposition.y, TPposition.z);
                Debug.Log("Move : Right"); 
            }
    }

}
