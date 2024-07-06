using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class GameManagerScript : MonoBehaviour
{
    public GameObject startZone;
    public GameObject endZone;
    public GameObject player;
    public TMP_Text timerText;
  
    public TMP_Text DebugText;
    public bool gameStarted;
    public float timerTime;
    public UnityExample UnityExampleScript;
    public GameObject UnityExample;
    // Start is called before the first frame update
    void Start()
    {
      timerText.text = "";
    }
    /*bool isNotZero(double x){
      if (x > 0 || x < 0 ){
        return true;
      }
      else{
        return false;
      }
    }*/
    // Update is called once per frame
    void Update()
    {
      UnityExampleScript = UnityExample.GetComponent<UnityExample>();
      /*for (int i = 0; i < UnityExampleScript.AllCollectionData.Count; i++){
        for (int j = 0; j < UnityExampleScript.AllCollectionData[i].Count; j++){
          for (int k = 0; k < UnityExampleScript.AllCollectionData[i][j].Count; k++){
            DebugText.text = DebugText.text + UnityExampleScript.AllCollectionData[i][j][k].ToString();
          }
        }
      }
      */
      if(gameStarted){
        timerTime = timerTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timerTime);
        timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
      }
      
    }
}
