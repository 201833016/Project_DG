using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlayScene");   // 게임 시작버튼 클릭시 Scene이 GamePlayScene이 되도록
    }

    public void OptionMenu()
    {
        // 옵션 Scene만들기
    }

    public void GameOut()
    {
        Application.Quit();
    }
}
