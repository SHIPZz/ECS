using UnityEngine;

namespace Code.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider
  {
    public GameObject LoadAsset(string path)
    {
      return UnityEngine.Resources.Load<GameObject>(path);
    }

    public T LoadAsset<T>(string path) where T : Component
    {
      return UnityEngine.Resources.Load<T>(path);
    }
  }
}