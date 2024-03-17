using UnityEngine;

public struct PreviewModel
{
    public GameObject Object;
    public string ID;

    public PreviewModel(GameObject gameObject, string iD)
    {
        Object = gameObject;
        ID = iD;
    }
}