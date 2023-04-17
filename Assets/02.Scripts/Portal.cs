using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    public LoadingScreen loadingScreen;
    public string transferMapName;
    private Player thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<Player>();
        }
        Debug.Log(thePlayer);
        Debug.Log(thePlayer.currentMapName);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("�浹 �Ͼ");
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("�÷��̾� �浹, ������ �Ѿ");
            thePlayer.currentMapName = transferMapName;
            Debug.Log(thePlayer.currentMapName);
            loadingScreen.LoadScene(transferMapName);
            //SceneManager.LoadScene(transferMapName);

        }
    }
}