using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class LoadCube : MonoBehaviour
{
    [SerializeField] private string assetAddress;
    [SerializeField] private GameObject myGameObject;

    // Start is called before the first frame update
    void Start()
    {
        LoadAsset(assetAddress);
    }

    void LoadAsset(string addressName)
    {   
        Addressables.LoadAssetAsync<GameObject>(addressName).Completed += LoadDone;
    }

    void LoadDone(AsyncOperationHandle<GameObject> obj)
    {
        myGameObject = obj.Result;
        Debug.Log("Finished loading asset");
        Instantiate(myGameObject, Vector3.zero, Quaternion.identity);
    }

}
