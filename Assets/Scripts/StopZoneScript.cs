using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System;

public class StopZoneScript : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;

    private float countdownToTP;
    public float finalTime;
    public TMP_Text finalTimeText;
    private GameManagerScript gameStartedScript;
    public bool stopPlayerMovement;
    public GameObject UnityExample;
    private UnityExample UnityExampleScript;
    // Start is called before the first frame update
    void Start()
    {
        gameStartedScript = gameManager.GetComponent<GameManagerScript>();
        countdownToTP = 10;
        stopPlayerMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        UnityExampleScript = UnityExample.GetComponent<UnityExample>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == player.name && gameStartedScript.gameStarted == true){
            while(countdownToTP > 0){
                countdownToTP = countdownToTP - Time.deltaTime;
            }
        gameStartedScript.gameStarted = false;
        UnityExampleScript.clk_Stop();
        /*finalTime = gameStartedScript.timerTime;
        TimeSpan time = TimeSpan.FromSeconds(finalTime);
        finalTimeText.text = "Congratulations, your final time was " + time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString() + "!";
        */
        player.transform.position = new Vector3(25.44f,1.144f,13.49f);
        stopPlayerMovement = true;
        }
    }
}
