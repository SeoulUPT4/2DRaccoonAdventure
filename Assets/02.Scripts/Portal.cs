using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    public LoadingScreen loadingScreen;
    public string transferMapName;
    //private Player thePlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("충돌 일어남");
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("플레이어 충돌, 페이지 넘어감");
            Player.Instance.currentMapName = transferMapName;
            Debug.Log(Player.Instance.currentMapName);
            loadingScreen.LoadScene(transferMapName);
            //SceneManager.LoadScene(transferMapName);

        }
    }
}