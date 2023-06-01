using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene("GamePlayScene");   // 게임 시작버튼 클릭시 Scene이 GamePlayScene이 되도록
        LoadingControllor.Instance.LoadScene("GamePlayScene");
        
    }

    public void OptionMenu()
    {
        // 옵션 Scene만들기
        LoadingControllor.Instance.LoadScene("SampleScene");
    }

    public void GameOut()
    {
        Application.Quit();
    }
}
