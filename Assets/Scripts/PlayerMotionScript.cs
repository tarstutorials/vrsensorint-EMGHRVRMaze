using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.XR.CoreUtils;

//This script is based on one from this video: https://www.youtube.com/watch?v=7bevpWbHKe4&t=25s&ab_channel=mrPCoding Thank you mrPCoding!
public class SwingingArmMotion : MonoBehaviour
{
    // Game Objects
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject ForwardDirection;
    public GameObject UnityExample;
    private UnityExample UnityExampleScript;
    private float normalizedLatestEMGData;
    private float latestHRData;
    public GameObject StopZone;
    private StopZoneScript stopZoneScript;
    public TMP_Text EMGText;
    public TMP_Text HRText;

    void Start()
    {
    }
    /*float CalcSpeedFromEMG(float emgData){
        emgData = Mathf.Abs(emgData);
        float Speed;
        if (emgData > 1){
            Speed = 5000;
            return Speed;
        }
        else{
            Speed = 0;
            return Speed;
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        UnityExampleScript = UnityExample.GetComponent<UnityExample>();
        normalizedLatestEMGData = (float)(UnityExampleScript.latestEMGData);
        latestHRData = (float)(UnityExampleScript.latestHRData);
        normalizedLatestEMGData = .025f * Mathf.Abs(normalizedLatestEMGData);
        stopZoneScript = StopZone.GetComponent<StopZoneScript>();
        // get forward direction from the center eye camera and set it to the forward direction object
        float yRotation = MainCamera.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);
        EMGText.text = "Latest EMG Data: " + normalizedLatestEMGData.ToString();
        HRText.text = "Latest HR Data " + latestHRData.ToString();
        if(Time.timeSinceLevelLoad > 1f && stopZoneScript.stopPlayerMovement == false)
        {
            transform.position += ForwardDirection.transform.forward * normalizedLatestEMGData * (latestHRData/60);
        }
    }
}