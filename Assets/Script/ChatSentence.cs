using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSentence : MonoBehaviour
{
    public string[] sentence;   // 대사 담을 배열 변수
    public Transform chatTr;    // 말풍선 위치 변수
    public GameObject chatBoxPrefab;    // 말풍선 프리팹


    public void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab); // 프리팹 생성
        go.GetComponent<Chat>().Ondialogue(sentence, chatTr);   // 메서드 호출(대사, 위치)
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))  // Player와 맞닿았을 경우
        {
            Debug.Log("상자 범위 내");
            // 임시적으로 p를 누르면 [Press "E"] 출력
            TalkNpc();  // 대사 출력
        }   
    }

    
}
