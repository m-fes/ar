using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class ARViewSettings : MonoBehaviour
{
    [SerializeField] private ARPointCloudManager pointCloudManager;
    [SerializeField] private ARPlaneManager planeManager;

    public void TogglePointCloud(bool show)
    {
        pointCloudManager.enabled = show;

        foreach (var pointCloud in pointCloudManager.trackables)
        {
            pointCloud.gameObject.SetActive(show);
        }
    }

    public void TogglePlanes(bool show)
    {
        planeManager.enabled = show;

        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(show);
        }
    }

    public void SetScanningMode(bool enable)
    {
        TogglePointCloud(enable);
        TogglePlanes(enable);
    }
}
