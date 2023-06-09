using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera; // 카메라 이동
    Vector3 cameraPosition; // 카메라 위치
    [SerializeField] private int speed = 10;   // 플레이어 이동 속도 
    private Vector2 speedVec;   // 가속도

    [Header("맵 넘어갈 이미지")] public Image Panel;    // Fade inout 용 canvas
    [Header("맵 이동 좌표")] public GameObject mapSpr;  // 카메라 lerp용

    //float time = 0f;
    //float FadeTime = 1f;
    void Update()
    {
        speedVec = Vector2.zero;    // 가속도 초기화
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

        GetComponent<Rigidbody2D>().velocity = speedVec;    // 스피드 저장
        
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        // 방 이동을 위한 Teleport
        if(other.CompareTag("TPT")) // 위 Teleport를 밟을 시
        {
            //StartCoroutine(FadeFlow()); // 페이드 인아웃 화면 전환

            Vector3 TPposition = this.transform.position;   // Player 위치 초기화
            this.transform.position = new Vector3(TPposition.x, TPposition.y + 5.5f, TPposition.z); // Player 위치 이동
            Debug.Log("Move : Top");    

            mapSpr.GetComponent<Move>().TopMap();   // 맵 위치 카메라 대상 위치 이동
        }
        else if(other.CompareTag("TPB"))    // 아래 Teleport를 밟을 시
        {
            //StartCoroutine(FadeFlow()); // 페이드 인아웃 화면 전환

            Vector3 TPposition = this.transform.position;   // Player 위치 초기화
            this.transform.position = new Vector3(TPposition.x, TPposition.y - 5.5f, TPposition.z); // Player 위치 이동
            Debug.Log("Move : Bottom"); 

            mapSpr.GetComponent<Move>().BottomMap();    // 맵 위치 카메라 대상 위치 이동
        }
        else if(other.CompareTag("TPL"))
        {
            //StartCoroutine(FadeFlow()); // 페이드 인아웃 화면 전환
            Vector3 TPposition = this.transform.position;
            this.transform.position = new Vector3(TPposition.x - 5.5f, TPposition.y, TPposition.z);
            Debug.Log("Move : Left"); 
            mapSpr.GetComponent<Move>().LeftMap();

            
        }
        else if(other.CompareTag("TPR"))
        {
            //StartCoroutine(FadeFlow()); // 페이드 인아웃 화면 전환

            Vector3 TPposition = this.transform.position;
            this.transform.position = new Vector3(TPposition.x + 5.5f, TPposition.y, TPposition.z);
            Debug.Log("Move : Right"); 

            mapSpr.GetComponent<Move>().RightMap();
        }


    
    }

/*
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while(alpha.a < 1f)
        {
            // 이미지의 알파 값이 1이하일 동안, 화면이 완전히 어두워질 동안
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(0.95f, 1f, time);
            Panel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(1f); // 1초의 대기시간.
        while(alpha.a > 0f)
        {
            // 이미지의 알파 값이 0이상일 동안, 화면이 완전히 밝아질 동안
            time += Time.deltaTime / FadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;

        }
        Panel.gameObject.SetActive(false);
        yield return null;   
    }
*/
}
