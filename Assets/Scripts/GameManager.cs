using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject progButton;

    public List<PookiePickup> pookieList = new List<PookiePickup>();

    public int pookieCount = 4;

    public int pookieActiveCount = 0;

    public bool checking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checking) 
        {

            pookieActiveCount = 0;

            for (int i = 0; i < pookieCount; i++)
            {
                if (pookieList[i].pookieActive == true)
                {
                    pookieActiveCount++;
                }
            }

            if (pookieActiveCount == pookieList.Count)
            {
                progButton.SetActive(true);
            }
            else
            {
                progButton.SetActive(false);
            }

            Debug.Log(pookieActiveCount);
        }    
    }
}



