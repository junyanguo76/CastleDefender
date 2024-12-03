using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAngle : MonoBehaviour
{
    public float rotateSpeed;
    float AngleX;
    float AngleY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();
    }
    private void LookAround()
    {
        float mouseY = Input.GetAxis("Mouse X");
        float mouseX = Input.GetAxis("Mouse Y");
        float lookAngleX= -mouseX * Time.deltaTime * rotateSpeed;
        float lookAngleY = mouseY * Time.deltaTime * rotateSpeed;
        
        AngleX += lookAngleX;
        AngleY += lookAngleY;
        AngleX = Mathf.Clamp(AngleX, -60, 60);
        transform.eulerAngles = new Vector3(AngleX,AngleY,0);


    }
}
