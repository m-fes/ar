using UnityEngine;

public class GyroCameraControl : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;
    private Quaternion rotFix;

    void Start()
    {
        gyroEnabled = EnableGyro();
        rotFix = new Quaternion(0, 0, 1, 0);
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotFix;
        }
    }
}
