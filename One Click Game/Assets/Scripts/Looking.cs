using UnityEngine;

public class Looking : MonoBehaviour
{
    public float lookSensitivity;  
    public Transform Cam;
    float CamX;
    float Rotx;

    void Update()
    {
        Rotx = Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
        CamX += Rotx;
        Cam.RotateAround(transform.position, transform.up, Rotx);
        Cam.rotation = Quaternion.Euler(0, CamX, 0);
        transform.rotation = Cam.rotation;
    }
}
