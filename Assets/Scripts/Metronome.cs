using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{

    const float INTERVAL = 0.5f;

    public float timer = 0f;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.checking) {

            timer += Time.deltaTime;

            if (timer >= INTERVAL)
            {
                Debug.Log("Tick");
                for (int i = 0; i < gameManager.pookieCount; i++)
                {
                    gameManager.pookieList[i].PlayAudio();
                }
            
            timer = 0f;
            }
        }
        
    }
}
