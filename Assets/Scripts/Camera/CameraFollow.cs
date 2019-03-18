using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //该脚本绑定在摄像机上
    public float mouseSpeedX = 10;
    public float mouseSpeedY = -10;
    public float maxAngleY = 50;
    public float minAngleY = -20;
    public float distance = 5;
    // Update is called once per frame
    float x = 0;
    float y = 0;
    private void Start()
    {

    }

    void Update()
    {
        Camera.main.transform.LookAt(this.transform);
        //Demo版本仅支持pc

        x += Input.GetAxis("Mouse X") * mouseSpeedX * Time.deltaTime;
        y += Input.GetAxis("Mouse Y") * mouseSpeedY * Time.deltaTime;
        if (y >= maxAngleY)
            y = maxAngleY;
        else if (y <= minAngleY)
            y = minAngleY;
        Quaternion q = Quaternion.Euler(y, x, 0);
        Vector3 direction = q * Vector3.forward;

        this.transform.position = this.transform.parent.position - direction * distance;
        this.transform.LookAt(this.transform.parent);

    }
}
