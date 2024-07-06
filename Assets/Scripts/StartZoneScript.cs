using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZoneScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;

    public GameManagerScript gameStartedScript;
    // Start is called before the first frame update
    void Start()
    {
        gameStartedScript = gameManager.GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name && gameStartedScript.gameStarted == false){
            gameStartedScript.gameStarted = true;
        }
    }
}
