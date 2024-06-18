using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static object lockObject = new object();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if(applicationIsQuitting)
            {
                return null;
            }

            lock(lockObject)
            {
                if(instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if(FindObjectsOfType(typeof(T)).Length > 1 ) 
                    { 
                        return instance;
                    }
                }

                if(instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";

                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }
    private void OnDestroy()
    {
        applicationIsQuitting =true;
    }
}

public class GameManager : Singleton<GameManager>
{
    public int scoreToCash = 0;

    //  UI: 나중에 UIManager로 옮기기
    public Canvas alwaysOnDisplay;
    public Canvas HUDCanvas;
    public Canvas SolitudeCanvas;

    public GameObject storePanel;
    public GameObject optionPanel;
    public GameObject InvenPanel;
    public GameObject GameOverPanel;
    public GameObject GameSuccessPanel;


    void Start()
    {
        alwaysOnDisplay.gameObject.SetActive(true);
        HUDCanvas.gameObject.SetActive(true);
        SolitudeCanvas.gameObject.SetActive(true);
        GameOverPanel.gameObject.SetActive(false);
        GameSuccessPanel.gameObject.SetActive(false);
    }

    void GetCash()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0f;
  
        HUDCanvas.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(true);
    }

    public void NextStage()
    {

    }

    public void ShowUI(Button clickedButton)
    {
        storePanel.gameObject.SetActive(false);
        optionPanel.gameObject.SetActive(false);

        if (clickedButton.name == "OptionBtn")
            optionPanel.gameObject.SetActive(true);
        else if (clickedButton.name == "StoreBtn")
            storePanel.gameObject.SetActive(true);
        else if (clickedButton.name == "InvenBtn")
        {
            InvenPanel.gameObject.SetActive(true);
            return;
        }
        Time.timeScale = 0f;
        HUDCanvas.gameObject.SetActive(false);
    }

    public void CloseUI(Button clickedButton)
    {

        if (clickedButton.name == "QuitOptionBtn")
            optionPanel.gameObject.SetActive(false);
        else if (clickedButton.name == "QuitStoreBtn")
            storePanel.gameObject.SetActive(false);
        else if (clickedButton.name == "LogBtn")
        {
            InvenPanel.gameObject.SetActive(false);
            return;
        }
        HUDCanvas.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
}
