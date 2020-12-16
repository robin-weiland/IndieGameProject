using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Actions : MonoBehaviour
{
    private GameObject doorLocked, doorUnlocked, doorOpened, player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("RunCharacter");
        doorLocked = GameObject.Find("DoorLocked");
        doorUnlocked = GameObject.Find("DoorUnlocked");
        doorOpened = GameObject.Find("DoorOpen");
        doorUnlocked.SetActive(false);
        doorOpened.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x >= 20.02f)
        {
            doorLocked.SetActive(false);
            doorUnlocked.SetActive(true);
        }
        if(player.transform.position.x >= 23.4f)
        {
            doorUnlocked.SetActive(false);
            doorOpened.SetActive(true);
        }
        if(player.transform.position.x >= 27f)
        {
            player.SetActive(false);
        }
    }
}
