using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PookieRand : MonoBehaviour
{

    Color colour1;

    // Start is called before the first frame update
    void Start()
    {
        colour1 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        this.GetComponent<UnityEngine.UI.Image>().color = colour1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
