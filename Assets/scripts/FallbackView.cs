using UnityEngine;

public class FallbackView : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject ShowObject(GameObject prefab)
    {
        return Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

}
