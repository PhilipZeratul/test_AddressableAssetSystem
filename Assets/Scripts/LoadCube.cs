using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;


public class LoadCube : MonoBehaviour
{
    [SerializeField] private string assetAddress;
    [SerializeField] private GameObject myGameObject;

    private bool isDone = false;
    private WaitForSeconds waitForHalfSecond = new WaitForSeconds(0.5f);

    private IEnumerator Start()
    {
        //LoadAsset(assetAddress);

        while (true)
        {
            //if (isDone)
            //{
                //Instantiate(myGameObject, Vector3.zero, Quaternion.identity);
                InstantiateAsset(assetAddress);                
            //}
            yield return waitForHalfSecond;
        }
    }

    private void LoadAsset(string address)
    {   
        Addressables.LoadAssetAsync<GameObject>(address).Completed += LoadDone;
    }

    private void LoadDone(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
            myGameObject = obj.Result;

        Addressables.Release(obj);
        Debug.Log("Finished loading asset");
    }

    private void InstantiateAsset(string address)
    {
        Addressables.InstantiateAsync(address).Completed += InstantiateDone;
    }

    private void InstantiateDone(AsyncOperationHandle<GameObject> obj)
    {
        Debug.Log("Finished instantiating asset");
    }
}
