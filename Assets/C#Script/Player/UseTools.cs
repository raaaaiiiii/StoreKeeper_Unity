using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UseTools : MonoBehaviour
{
    public GameObject player;
    public PlayerEnventory playerEnventory;
    public List<GameObject> tools = new List<GameObject>();
    public int key;
    public int usingtool;
    public List<int> numkeylist = new List<int>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.inputString);
        if (Input.anyKeyDown)
        {
            string key = Input.inputString;
            if (int.TryParse(key, out int keyinput))
            {


                bool exist = numkeylist.Contains(keyinput);
                if (exist)
                {
                    int tool = int.Parse(key);
                    for (int i = 0; tools.Count > i; i++)
                    {
                        tools[i].SetActive(false);
                    }
                    if (usingtool != tool)
                    {
                        tools[tool - 1].SetActive(true);
                        usingtool = tool;
                    }
                    else
                    {
                        usingtool = 0;
                    }
                }
            }
            else
            {
                Debug.Log(key);
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            int tool = 1;
            for (int i = 0; tools.Count > i; i++)
            {
                tools[i].SetActive(false);
            }
            if (usingtool != tool)
            {
                tools[tool - 1].SetActive(true);
                usingtool = tool;
            }
            else
            {
                usingtool = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            int tool = 2;
            for (int i = 0; tools.Count > i; i++)
            {
                tools[i].SetActive(false);
            }
            if (usingtool != tool)
            {
                tools[tool - 1].SetActive(true);
                usingtool = tool;
            }
            else
            {
                usingtool = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            int tool = 3;
            for (int i = 0; tools.Count > i; i++)
            {
                tools[i].SetActive(false);
            }
            if (usingtool != tool)
            {
                tools[tool - 1].SetActive(true);
                usingtool = tool;
            }
            else
            {
                usingtool = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            int tool = 4;
            for (int i = 0; tools.Count > i; i++)
            {
                tools[i].SetActive(false);
            }
            if (usingtool != tool)
            {
                tools[tool - 1].SetActive(true);
                usingtool = tool;
            }
            else
            {
                usingtool = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            int tool = 5;
            for (int i = 0; tools.Count > i; i++)
            {
                tools[i].SetActive(false);
            }
            if (usingtool != tool)
            {
                tools[tool - 1].SetActive(true);
                usingtool = tool;
            }
            else
            {
                usingtool = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            int tool = 6;
            for (int i = 0; tools.Count > i; i++)
            {
                tools[i].SetActive(false);
            }
            if (usingtool != tool)
            {
                tools[tool - 1].SetActive(true);
                usingtool = tool;
            }
            else
            {
                usingtool = 0;
            }
        }*/
    }
}
