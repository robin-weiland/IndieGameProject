using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchInLevel2 : MonoBehaviour
{
    public int index;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jump04");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y <= -2.7f)
        {
            SceneManager.LoadScene(index);
        }
    }
}
