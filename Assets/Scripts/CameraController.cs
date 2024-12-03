using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public GameObject mainCamera;
    public GameObject bowlCamera;

    public float hideTimer;
    public float waitTime;

    public GameObject bowl;
    LookAngle bowlAngle;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.SetActive(true);
        bowlCamera.SetActive(false);
        bowlAngle = bowl.GetComponent<LookAngle>();
        bowlAngle.enabled = false;
        instance = this;
        waitTime = 2;
    }

    public void ChangingToBowlCamera()
    {
        mainCamera.SetActive(false);
        bowlCamera.SetActive(true);
        bowlAngle.enabled = true;
    }

    public void ChangingToNormalCamera()
    {
        bowlCamera.SetActive(false);
        mainCamera.SetActive(true);
        bowlAngle.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(bowlCamera.activeSelf == true && Input.GetMouseButtonDown(0) && Time.time >= hideTimer)
        {
            Bowl.Instance.ShootingByClick();
            hideTimer = Time.time + waitTime;
        }
        if (bowlCamera.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            ChangingToNormalCamera();
        }


    }
}
