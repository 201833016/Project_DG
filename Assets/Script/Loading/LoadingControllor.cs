using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingControllor : MonoBehaviour
{
    private static LoadingControllor instance;  // 로딩 싱글톤
    public static LoadingControllor Instance
    {
        get
        {
            if(instance == null)
            {
                var obj = FindObjectOfType<LoadingControllor>();
                if(obj != null)
                {
                    instance = obj;
                }
                else
                {
                    instance = Create();
                }
            }
            return instance;
        }
    }

    private static LoadingControllor Create()
    {
        return Instantiate(Resources.Load<LoadingControllor>("Prefab/Loading/LoadingUI"));  // 로딩 UI초기화 방지
    }

    private void Awake() {
        if(Instance != this)    // 자기자신 일치 하지 않으면 파괴
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);  // Scene을 옮기는 중에서 파괴 방지
    }
    [SerializeField] private CanvasGroup canvasGroup;   // 로딩 UI가 있는 Canvas
    public Image progressBar;   // 로딩 바 이미지
    private string loadSceneName;   // 불러오려는 Scene

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true); 
        SceneManager.sceneLoaded += OnSceneLoaded;  // 로딩이 끝나는 순간 
        loadSceneName = sceneName;  // 적어둔 씬 이름 가져오기
        StartCoroutine(LoadSceneProgress());    // 코루틴 함수 호출
    }

    private IEnumerator LoadSceneProgress()
    {
        progressBar.fillAmount = 0f;    // 로딩 0%
        yield return StartCoroutine(Fade(true));    // 페이드 인

        AsyncOperation op = SceneManager.LoadSceneAsync(loadSceneName); // Scene불러오기
        op.allowSceneActivation = false;    // Scene의 로딩이 끝나도 Scene전환을 하지 않도록

        // 로딩 바
        float timer = 0f;
        while(!op.isDone)   // Scene 로딩이 끝나지 않은 상태일 경우
        {
            yield return null;  // 반복마다 제어권 전달

            if(op.progress < 0.9f)  // 로딩바가 90% 이하면
            {
                progressBar.fillAmount = op.progress;   // 로딩 진행도 표시
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);   // 90%에서 100%로 1초 동안 채우도록
                if(progressBar.fillAmount >= 1f)    // 로딩바 100%라면
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
                
            }
        }
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if(arg0.name == loadSceneName)  // 불러옥자 한 Scene이 불려져 오면
        {
            StartCoroutine(Fade(false));    // 페이드 아웃
            SceneManager.sceneLoaded -= OnSceneLoaded;  // 콜백 제거하여 중첩 방지
        }
    }

    private IEnumerator Fade(bool isFadeIn) // 페이드 인, 아웃
    {
        float timer = 0f;
        while(timer <= 1f)  // 타이머가 1이 될때까지
        {
            yield return null;
            timer += Time.unscaledDeltaTime;    // 타이머 증가
            canvasGroup.alpha = isFadeIn ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer); // isFadeIn이 true면 페이드 인, false면 페이드 아웃

            if(!isFadeIn)
            {
                gameObject.SetActive(false);    // UI 비활성화
            }
        }
    }
}

