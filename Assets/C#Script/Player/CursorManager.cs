using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public GameMenu gameMenu;
    public bool isCursorVisible=false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=isCursorVisible;
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CursorManager_Gamemenu(bool isgamemenu)
    {
        Cursor.visible=!isgamemenu;
        if (isgamemenu)
        {
            Cursor.lockState=CursorLockMode.None;
        }
        else
        {
            Cursor.lockState=CursorLockMode.Locked;
        }
    }
}
