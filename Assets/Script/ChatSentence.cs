using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatSentence : MonoBehaviour
{
    public string[] sentence;
    public Transform chatTr;
    public GameObject chatBoxPrefab;


    public void TalkNpc()
    {
        GameObject go = Instantiate(chatBoxPrefab);
        go.GetComponent<Chat>().Ondialogue(sentence, chatTr);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("상자 범위 내");
            // 임시적으로 p를 누르면 [Press "E"] 출력
            TalkNpc();
        }   
    }

    
}
