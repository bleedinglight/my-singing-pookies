using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Pookie Management")]

    public List<PookieData> pookieList = new List<PookieData>();

    public int pookieCount = 4;

    public int pookieActiveCount = 0;

    public bool checking = false;

    [Header("UI")]

    private GameObject hotbar;

    [Header("Round UI")]

    public int roundCount = 1;

    public GameObject progButton;

    public TMPro.TextMeshProUGUI roundText;

    [Header("Pookie Prefab")]

    public GameObject pookiePrefab;

    [Header("Pookie Types")]

    public List<GameObject> pookieTypes = new List<GameObject>();

    

    // Start is called before the first frame update
    void Start()
    {
        //roundText = GameObject.Find("RoundText").GetComponent<TMPro.TextMeshProUGUI>();
        roundText.text = "Round " + roundCount;

        hotbar = GameObject.Find("Hotbar");

        PookieInit();       
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

            // if (pookieActiveCount == pookieCount)
            // {
            //     progButton.SetActive(true);
            // }
            // else
            // {
            //     progButton.SetActive(false);
            // }

            Debug.Log(pookieActiveCount);
        }    
    }

    public void AdvanceRound()     
    {

        checking = false;
        roundCount++;
        roundText.text = "Round " + roundCount;

        for (int i = 0; i < pookieCount; i++)
        {
            Destroy(pookieList[i].gameObject);
        }

        pookieList.Clear();

        Invoke("PookieInit", 0.1f);

    }

    void PookieInit() 
    {
        // for (int i = 0; i < pookieCount; i++) {

        //     int pookieToBeGenerated = Random.Range(0, pookieTypes.Count);
        //     bool dupeCheck = false;

        //     for (int j = 0; j < pookieCount; j++)
        //     {
        //         if (pookieToBeGenerated == pookieList[j].pookieID)
        //         {
        //             i--;
        //             dupeCheck = true;
        //             break;
        //         }
            
        //     }

        //     if (dupeCheck == false)
        //     {
        //         GameObject pookie = Instantiate(pookieTypes[pookieToBeGenerated], transform.position, Quaternion.identity);
        //         pookie.transform.SetParent(hotbar.transform);
        //         pookieList.Add(pookie.GetComponent<PookieData>());

        //     }

        checking = false;

        for (int i = 0; i < pookieCount; i++)
        {
            GameObject pookie = Instantiate(pookieTypes[Random.Range(0, pookieTypes.Count)], transform.position, Quaternion.identity);
            pookie.transform.SetParent(hotbar.transform);

            bool dupeCheck = false;
            
            //dupe protection

            for (int j = 0; j < pookieList.Count; j++)
            {
                if (pookieList[j].pookieID == pookie.GetComponent<PookieData>().pookieID)
                {
                    Destroy(pookie);
                    dupeCheck = true;
                    i--;
                    break;
                }
            } 

            //the pookies expand to 2.7 times scale for no reason unless i do this
            //pookie.transform.localScale = new Vector3(1, 1, 1);
            if (dupeCheck == false) 
            {
                pookieList.Add(pookie.GetComponent<PookieData>());
            }
        }

        checking = true;

    }

    public void PlayAllAudio()
    {
        for (int i = 0; i < pookieList.Count; i++)
        {
            pookieList[i].PlayAudio();
        }
    }

    /*void SaveAudio()
    {
        for (int i = 0; i < pookieList.Count; i++)
        {
            if (pookieList[i].pookieActive)
            {

            }
        }
    }*/
}