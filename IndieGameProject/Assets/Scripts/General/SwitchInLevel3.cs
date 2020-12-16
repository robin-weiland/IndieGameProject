using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchInLevel3 : MonoBehaviour
{
    private GameObject player;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("RunCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x >= 28.4f)
        {
            SceneManager.LoadScene(index);
        }
    }
}
