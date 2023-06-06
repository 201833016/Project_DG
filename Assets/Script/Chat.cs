using System.Collections;
using System.Collections.Generic;
using TMPro;    // textmesh를 위한 네임 스페이스 추가
using UnityEngine;

public class Chat : MonoBehaviour
{
    public Queue<string> sentences; // 대사 queue
    public string currentSentence;  // while반복문에서 queue의 데이터를 잠시 1개씩 보관
    public TextMeshPro text;
    public GameObject quad;     // 말풍선 사이즈

    public void Ondialogue(string[] lines, Transform chatPoint) // 대사를 queue에 저장
    {
        sentences = new Queue<string>();    // queue 초기화
        transform.position = chatPoint.position;    // 말풍선 위치
        sentences.Clear();
        foreach(var line in lines)
        {
            sentences.Enqueue(line);    // queue에 순서대로 넣기
        }
        StartCoroutine(DialogueFlow(chatPoint));    // IEnumerator에서 정의한 것을 코루틴에 적음
    }

    IEnumerator DialogueFlow(Transform chatPoint)
    {
        yield return null;
        while (sentences.Count > 0) // queue의 갯수만큼 대사를 Text에 넣음
        {
            currentSentence = sentences.Dequeue();
            text.text = currentSentence;    // 대사 담기

            float x = text.preferredWidth;  // 현재 말풍선 가로 길이
            x = (x>3)?3:x+0.3f;         // x가 3이하면 0.3픽셀 추가
            quad.SetActive(true);

            quad.transform.localScale = new Vector2(x, text.preferredHeight + 0.3f);    // 세로 0.3만큼 길게, 말풍선 길이 초기화

            transform.position = new Vector2(chatPoint.position.x, chatPoint.position.y + text.preferredHeight / 2);    // 말풍선 위치를 받고 초기화, y는 절반
            yield return new WaitForSeconds(2f);    // 다음 대사 쉬는 시간, 2초후 진행
        }
        Destroy(gameObject);    // 다한 대사 말풍선 파괴
    }
}
