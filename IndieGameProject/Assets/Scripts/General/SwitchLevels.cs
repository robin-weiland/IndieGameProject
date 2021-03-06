﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevels : MonoBehaviour
{
    public int index;
    public float playerEndPositionX;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Run_01");
        playerEndPositionX = 22.85f;
    }

    void Update()
    {
        if (player.transform.position.x >= playerEndPositionX)
        {
            SceneManager.LoadScene(index);
        }
    }
}
