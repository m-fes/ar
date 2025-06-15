using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARTapToPlace : MonoBehaviour
{
    public ARView arView;                    
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        var touch = Touchscreen.current?.primaryTouch;
        if (touch == null || !touch.press.wasPressedThisFrame) return;

        Vector2 screenPos = touch.position.ReadValue();
        if (raycastManager.Raycast(screenPos, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            arView.PlaceObject(hitPose.position);
        }
    }
}
