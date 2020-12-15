using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Actions : MonoBehaviour
{
    private GameObject firstAction, secondAction;

    void Start()
    {
        firstAction = GameObject.Find("Run_01");
        secondAction = GameObject.Find("Jump04");
        secondAction.SetActive(false);
    }

    void Update()
    {
        if(firstAction.transform.position.x > 10.16f)
        {
            firstAction.SetActive(false);
            secondAction.SetActive(true);
        }
    }

    
}
