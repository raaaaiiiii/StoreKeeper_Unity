using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stocker : MonoBehaviour
{
    public int stockitem=0;
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text=stockitem.ToString();
    }
}
