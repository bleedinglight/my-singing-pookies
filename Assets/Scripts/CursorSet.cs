using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSet : MonoBehaviour
{
    [SerializeField] private Vector2 cursorOffset;
    private float minX, minY, maxX, maxY;

    //im not gonna comment this because its just a cursor lol

    private GameObject cursorObject;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        cursorObject = GameObject.Find("CursorObject");
        //SetMinAndMax();
    }

    // Update is called once per frame
    void Update()
    {
        cursorObject.transform.position = new Vector2(Input.mousePosition.x + cursorOffset.x, Input.mousePosition.y + cursorOffset.y);
        /*if (cursorObject.transform.position.x < minX)
        {
            Debug.Log("minX");
            cursorObject.transform.position = new Vector2(minX + cursorOffset.x, cursorObject.transform.position.y);
        }
        if (cursorObject.transform.position.x > maxX)
        {
            Debug.Log("maxX");
            cursorObject.transform.position = new Vector2(maxX - cursorOffset.x, cursorObject.transform.position.y);
        }
        if (cursorObject.transform.position.y < minY)
        {
            Debug.Log("minY");
            cursorObject.transform.position = new Vector2(cursorObject.transform.position.x, minY + cursorOffset.y);
        }
        if (cursorObject.transform.position.y > maxY)
        {
            Debug.Log("maxY");
            cursorObject.transform.position = new Vector2(cursorObject.transform.position.x, maxY - cursorOffset.y);
        }*/
    }

    /*private void SetMinAndMax()
    {
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        minX = -bounds.x;
        minY = -bounds.y;
        maxX = bounds.x;
        maxY = bounds.y;
    }*/
}
