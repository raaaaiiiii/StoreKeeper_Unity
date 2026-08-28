using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMenu : MonoBehaviour
{
    public GameObject gamemenuCanvas;
    public CursorManager cursorManager;
    public bool isGamemenunow=false;
    public float gamespeedscale;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=gamespeedscale;
        gamemenuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGamemenunow=!isGamemenunow;
            gamemenuCanvas.SetActive(isGamemenunow);
            GameMenuChange();
        }
    }
    public void GameMenuChange()
    {
        cursorManager.CursorManager_Gamemenu(isGamemenunow);
        //Debug.Log("cursormanager_change");
        gamemenuCanvas.SetActive(isGamemenunow);
        if (isGamemenunow)
        {
            Time.timeScale=0;
            //Debug.Log("timescale0");
        }
        else
        {
            Time.timeScale=gamespeedscale;
            //Debug.Log("timescale1");
        }
    }
}
