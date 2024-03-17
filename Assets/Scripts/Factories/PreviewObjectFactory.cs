using UnityEngine;

public class PreviewObjectFactory
{
    public GameObject Create(GameObject modelPrefab, Transform parent)
    {
        return Object.Instantiate(modelPrefab, parent);
    }
}