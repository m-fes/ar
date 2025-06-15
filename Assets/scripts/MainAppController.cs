using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

public class MainAppController : MonoBehaviour
{
    [Header("Dependencies")]
    public InteractionController interactionController;
    private GameObject selectedPrefab;
    public Camera mainSceneCamera;

    private bool isARMode;          
    private bool arSceneLoaded;     

    void Start()
    {
        StartCoroutine(CheckARSupportAndStart());
    }

    private IEnumerator CheckARSupportAndStart()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            yield return ARSession.CheckAvailability();
            bool arSupported = ARSession.state != ARSessionState.Unsupported;

            if (arSupported && EnsureCameraPermission())
            {
                yield return LoadARScene();   
                SwitchToAR();
            }
            else
            {
                SwitchToFallback();
            }
        }
        else
        {
            SwitchToFallback();
        }
    }

    private bool EnsureCameraPermission()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Camera)) return true;

        Permission.RequestUserPermission(Permission.Camera);
        return Permission.HasUserAuthorizedPermission(Permission.Camera);
    }

    public void ToggleMode()   
    {
        if (isARMode)
            SwitchToFallback();
        else
            StartCoroutine(SwitchToARWithChecks());
    }

    private IEnumerator SwitchToARWithChecks()
    {
        
        if (!arSceneLoaded) yield return LoadARScene();

        if (!EnsureCameraPermission()) yield break;

        SwitchToAR();
    }

    private IEnumerator LoadARScene()
    {
        arSceneLoaded = true;
        var op = SceneManager.LoadSceneAsync("ARScene", LoadSceneMode.Additive);
        yield return op;                    

        interactionController.InitARView();  
    }

    private void SwitchToAR()
    {
        isARMode = true;
        mainSceneCamera.enabled = false;
        interactionController.DisplayObject(selectedPrefab, true);
    }

    private void SwitchToFallback()
    {
        isARMode = false;
        mainSceneCamera.enabled = true;
        interactionController.DisplayObject(selectedPrefab, false);
        SceneManager.UnloadSceneAsync("ARScene");
        arSceneLoaded = false;
    }

    public void SetSelectedPrefab(GameObject prefab)
    {
        selectedPrefab = prefab;
        if (isARMode)
        {
            interactionController.DisplayObject(selectedPrefab, true);
        }
        else
        {
            interactionController.DisplayObject(selectedPrefab, false);
        }
    }

}
