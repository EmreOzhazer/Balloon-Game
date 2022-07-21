/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{

    private static GameOverWindow instance;

    private void Awake()
    {
        instance = this;

        transform.Find("retryBtn").GetComponent<Button_UI>().ClickFunc = Retry;
        instance.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (gameObject.activeSelf)
            {
                Retry();
            }
        }
    }

    private void Retry()
    {
        //Coin.ResetCoinCount();
        SceneManager.LoadScene(0);
    }

    public static void Show()
    {
        instance.gameObject.SetActive(true);
    }

}

