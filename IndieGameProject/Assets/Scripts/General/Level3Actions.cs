using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Actions : MonoBehaviour
{
    private GameObject firstAction, secondAction, thirdAction;

    // Start is called before the first frame update
    void Start()
    {
        firstAction = GameObject.Find("JumpCharacter");
        secondAction = GameObject.Find("RunCharacter");
        secondAction.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(firstAction.transform.position.y <= -0.1f)
        {
            firstAction.SetActive(false);
            secondAction.SetActive(true);
        }
    }
}
