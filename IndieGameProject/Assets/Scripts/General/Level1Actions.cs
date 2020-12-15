using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Actions : MonoBehaviour
{
    private GameObject firstAction, secondAction, thirdAction;
    // Start is called before the first frame update
    void Start()
    {
        firstAction = GameObject.Find("Run_01");
        secondAction = GameObject.Find("Jump04");
        thirdAction = GameObject.Find("Run_02");
        secondAction.SetActive(false);
        thirdAction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(firstAction.transform.position.x > 10.89f)
        {
            firstAction.SetActive(false);
            secondAction.SetActive(true);
        }
        else if(secondAction.transform.position.x > 11.0f)
        {
            secondAction.SetActive(false);
            thirdAction.SetActive(true);
        }
    }
}
