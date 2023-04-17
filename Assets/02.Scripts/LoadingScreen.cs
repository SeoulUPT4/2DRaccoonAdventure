using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    public GameObject hpUI;
    // 로딩 화면을 표시하는 Canvas 객체
    public GameObject loadingScreen;

    public Slider loadingBar;

    private void Update()
    {
        if(loadingScreen.activeSelf==false)
        {
            hpUI.SetActive(true);
        }
        else
        {
            hpUI.SetActive(false);
        }
    }

    // 씬을 로드하는 함수
    public void LoadScene(string sceneName)
    {
        // 로딩 화면을 표시
        loadingScreen.SetActive(true);

        // 비동기식으로 씬을 로드
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // 씬을 비동기식으로 로드하는 함수
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // 로딩바 초기화
        loadingBar.value = 0;

        // 씬 로딩이 완료될 때까지 기다림
        while (!asyncLoad.isDone)
        {
            // 로딩바 업데이트
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingBar.value = progress;

            yield return null;
        }
    }
}