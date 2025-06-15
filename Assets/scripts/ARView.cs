using System.Collections.Generic;
using UnityEngine;

public class ARView : MonoBehaviour
{
    private GameObject prefabToPlace;
    private readonly List<GameObject> placed = new();  

    public void ShowObject(GameObject prefab) => prefabToPlace = prefab;

    public void PlaceObject(Vector3 position)
    {
        if (prefabToPlace == null) return;

        GameObject obj = Instantiate(prefabToPlace, position, Quaternion.identity);
        placed.Add(obj);                
        prefabToPlace = null;
    }

    public void ClearPlacedObjects()
    {
        foreach (var o in placed)
            if (o) Destroy(o);

        placed.Clear();
    }
}
