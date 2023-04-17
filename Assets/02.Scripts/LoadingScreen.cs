using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    public GameObject hpUI;
    // �ε� ȭ���� ǥ���ϴ� Canvas ��ü
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

    // ���� �ε��ϴ� �Լ�
    public void LoadScene(string sceneName)
    {
        // �ε� ȭ���� ǥ��
        loadingScreen.SetActive(true);

        // �񵿱������ ���� �ε�
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // ���� �񵿱������ �ε��ϴ� �Լ�
    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // �ε��� �ʱ�ȭ
        loadingBar.value = 0;

        // �� �ε��� �Ϸ�� ������ ��ٸ�
        while (!asyncLoad.isDone)
        {
            // �ε��� ������Ʈ
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingBar.value = progress;

            yield return null;
        }
    }
}