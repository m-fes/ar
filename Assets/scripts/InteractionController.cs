using UnityEngine;
using UnityEngine.UIElements;

public class InteractionController : MonoBehaviour
{
    private ARView arView;
    public FallbackView fallbackView;
    GameObject currentObj;

    public void InitARView()
    {
        arView = FindFirstObjectByType<ARView>();
    }

    public void DisplayObject(GameObject prefab, bool useAR)
    {
        Clear();                       

        if (useAR)
        {
            if (arView == null)
            {
                InitARView();
            }

            if (arView != null)
            {
                arView.ShowObject(prefab);
            }
        }
        else
        {
            currentObj = fallbackView.ShowObject(prefab);
        }
    }

    void Clear()
    {
        if (currentObj != null) Destroy(currentObj);

        if (arView) arView.ClearPlacedObjects();
    }
}
