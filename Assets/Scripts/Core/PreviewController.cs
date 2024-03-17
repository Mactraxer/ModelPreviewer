using System.Collections.Generic;
using UnityEngine;

public class PreviewController : MonoBehaviour
{
    [SerializeField] private Transform _previewObjectContainer;
    [SerializeField] private PreviewerUI _previewerUI;
    [SerializeField] private TablePreviewItem _tablePreviewItemPrefab;
    [SerializeField] private List<PreviewModelConfig> _previewModelConfigs;

    private PreviewObjectFactory _previewObjectFactory;
    private UIFactory _uiFactory;

    private List<PreviewModel> _previewModels;

    private void Start()
    {
        _previewObjectFactory = new PreviewObjectFactory();
        _uiFactory = new UIFactory(_tablePreviewItemPrefab);

        _previewModels = new List<PreviewModel>(_previewModelConfigs.Count);

        _previewerUI.OnTapAddRowButton += OnTapAddRowButton;
        _previewerUI.OnSelectRow += OnSelectRow;

        _previewerUI.Init(_uiFactory);
        _previewerUI.Setup(GetViewModels(_previewModelConfigs));
        CreatePreviewObjects(_previewModelConfigs);
        SelectPreviewModel(_previewModelConfigs[0].ID);
    }

    private void OnSelectRow(string objectID)
    {
        SelectPreviewModel(objectID);
    }

    private void SelectPreviewModel(string objectID)
    {
        foreach (var model in _previewModels)
        {
            if (model.ID == objectID)
            {
                model.Object.SetActive(true);
            }
            else
            {
                model.Object.SetActive(false);
            }
        }
    }

    private void CreatePreviewObjects(List<PreviewModelConfig> previewModelConfigs)
    {
        foreach (var config in previewModelConfigs)
        {
            CreatePreviewObject(config);
        }
    }
    private void CreatePreviewObject(PreviewModelConfig config)
    {
        _previewModels.Add(new PreviewModel(_previewObjectFactory.Create(config.ModelPrefab, _previewObjectContainer), config.ID));
    }

    private ModelViewObjectPreview[] GetViewModels(List<PreviewModelConfig> previewModelConfigs)
    {
        var result = new ModelViewObjectPreview[previewModelConfigs.Count];

        for (int index = 0; index < previewModelConfigs.Count; index++)
        {
            result[index] = GetViewModel(previewModelConfigs[index]);
        }

        return result;
    }

    private ModelViewObjectPreview GetViewModel(PreviewModelConfig previewModelConfig)
    {
        return new ModelViewObjectPreview(previewModelConfig.ID, previewModelConfig.ModelName);
    }

    private void OnTapAddRowButton()
    {
        AddRandomPreviewModel();
    }

    private void AddRandomPreviewModel()
    {
        var newRandomConfig = ScriptableObject.CreateInstance<PreviewModelConfig>();
        var randomConfig = _previewModelConfigs[Random.Range(0, _previewModelConfigs.Count)];
        newRandomConfig.Setup(randomConfig.ModelPrefab, randomConfig.ModelName);
        _previewModelConfigs.Add(newRandomConfig);
        CreatePreviewObject(newRandomConfig);
        var viewModel = GetViewModel(newRandomConfig);
        _previewerUI.AddRow(viewModel);
    }
}
