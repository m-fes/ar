using UnityEngine;
using UnityEngine.UI;

public class ObjectCatalogUI : MonoBehaviour
{
    public MainAppController mainAppController;

    [Header("������")]
    public Button buttonCat;
    public Button buttonPlant;

    [Header("�������")]
    public GameObject prefabCat;
    public GameObject prefabPlant;

    [Header("������� UI")]
    public GameObject catalogPanel;

    void Start()
    {
        buttonCat.onClick.AddListener(() => SelectPrefab(prefabCat));
        buttonPlant.onClick.AddListener(() => SelectPrefab(prefabPlant));
    }

    void SelectPrefab(GameObject prefab)
    {
        mainAppController.SetSelectedPrefab(prefab);
        catalogPanel.SetActive(false); 
    }
}
