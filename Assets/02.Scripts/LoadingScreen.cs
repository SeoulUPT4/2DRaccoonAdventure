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
        if (hpUI != null)
        {
            if (loadingScreen.activeSelf == false)
            {
                hpUI.SetActive(true);
            }
            else
            {
                hpUI.SetActive(false);
            }
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
        yield return null;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        float timer = 0.0f;
        // �ε��� �ʱ�ȭ
        loadingBar.value = 0;

        // �� �ε��� �Ϸ�� ������ ��ٸ�
        while (!asyncLoad.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if(asyncLoad.progress<0.9f)
            {
                loadingBar.value = Mathf.Lerp(loadingBar.value, asyncLoad.progress, timer);
                if (loadingBar.value>=asyncLoad.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                loadingBar.value = Mathf.Lerp(loadingBar.value, 1f, timer);
                if(loadingBar.value==1.0f)
                {
                    asyncLoad.allowSceneActivation = true;
                    Debug.Log("Finish?");
                    yield break;
                }
            }

            // �ε��� ������Ʈ
/*            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingBar.value = progress;
*/
        }
    }
}