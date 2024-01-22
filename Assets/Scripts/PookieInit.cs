using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PookieInit : MonoBehaviour
{



    public GameObject pookiePrefab;

    private GameObject hotbar;

    [SerializeField] int pookieCount = 4;

    // Start is called before the first frame update
    void Start()
    {

        hotbar = GameObject.Find("Hotbar");

        for (int i = 0; i < pookieCount; i++)
        {
            GameObject pookie = Instantiate(pookiePrefab, transform.position, Quaternion.identity);
            pookie.transform.SetParent(hotbar.transform);
            //the pookies expand to 2.7 times scale for no reason unless i do this
            pookie.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
