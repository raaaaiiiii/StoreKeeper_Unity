using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolUnlock : MonoBehaviour
{
    public UseTools useTools;
    public List<GameObject> unlockedtools = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        useTools.numkeylist.Clear();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Unlocktool(int toolnum)
    {
        Debug.Log(toolnum);
        useTools.numkeylist.Add(toolnum);
        unlockedtools.Add(useTools.tools[toolnum-1]);
        Tool tool = useTools.tools[toolnum-1].GetComponent<Tool>();
        tool.unlocked=true;
    }
}
