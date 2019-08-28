using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class VariantTest : MonoBehaviour
{
    public Material mat;


    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public void LoadHD()
    {
        LoadTexture("tree", "HD");
    }

    public void LoadSD()
    {
        LoadTexture("tree", "SD");
    }

    private void LoadTexture(string address, string label)
    {
        //Addressables.LoadAssetAsync<Texture2D>("tree").Completed
        //Addressables.LoadAssetAsync<Texture2D>(new List<object> { address, label }).Completed
        //    += TextureLoaded;

        Addressables.LoadAssetsAsync<Texture2D>(new List<object> { address, label }, null, Addressables.MergeMode.Intersection).Completed
            += TextureLoaded;
    }

    private void TextureLoaded(AsyncOperationHandle<IList<Texture2D>> obj)
    {
        mat.mainTexture = obj.Result[0];
    }
}
