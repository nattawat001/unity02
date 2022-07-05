using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    int r= -20,b= 10,g= 20,sum=0;
    public TextMeshProUGUI txtDisplay,txtDisplay2,txtDisplay3;
    public float timeRemaining = 20;
    void Update()
    {
        if (timeRemaining > 0 )
        {
            timeRemaining -= Time.deltaTime;
            txtDisplay3.text = "TIME: " + timeRemaining.ToString("0");
        }
        else if (sum <= 0)
        {
            txtDisplay2.text = "Mission Failed";
        }
        
        
    
        
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                 if (hit.collider.gameObject.name.CompareTo("GSphere") == 0)
                {
                    hit.collider.gameObject.SetActive(false);
                    sum = sum + g;
                }


                if (hit.collider.gameObject.name.CompareTo("RSphere") == 0)
                {
                    hit.collider.gameObject.SetActive(false);
                    sum = sum + r;
                }

                
                if (hit.collider.gameObject.name.CompareTo("BSphere") == 0)
                {
                    hit.collider.gameObject.SetActive(false);
                    sum = sum + b;
                }

                Debug.Log(sum);
                txtDisplay.text = "Score: " + sum;

                if (sum == 120)
                {
                    txtDisplay2.text = "Mission Completed";
                    timeRemaining = 0;

                }
                else if (sum <= 0)
                {
                    txtDisplay2.text = "Mission Failed";
                    timeRemaining = 0;
                }

                



               
            }
        
            
        }
        
    }
}
