using UnityEngine;

[CreateAssetMenu(menuName = "Configs/PreviewModel", fileName = "PreviewModelConfig")]
public class PreviewModelConfig : ScriptableObject
{
    [SerializeField] private GameObject _modelPrefab;
    [SerializeField] private string _modelName;

    public GameObject ModelPrefab => _modelPrefab;
    public string ModelName => _modelName;
    public string ID => GetInstanceID().ToString();

    public void Setup(GameObject prefab, string name)
    {
        _modelPrefab = prefab;
        _modelName = name;
    }
}