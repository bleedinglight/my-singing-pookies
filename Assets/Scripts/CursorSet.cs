using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSet : MonoBehaviour
{


    //im not gonna comment this because its just a cursor lol

    private GameObject cursorObject;


    // Start is called before the first frame update
    void Start()
    {
        cursorObject = GameObject.Find("CursorObject");
    }

    // Update is called once per frame
    void Update()
    {
        cursorObject.transform.position = Input.mousePosition;
    }
}
