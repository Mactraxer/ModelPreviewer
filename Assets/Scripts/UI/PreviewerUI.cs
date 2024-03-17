using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewerUI : MonoBehaviour
{
    public event Action OnTapAddRowButton;
    public event Action<string> OnSelectRow;

    [SerializeField] private RectTransform _tableContainer;
    [SerializeField] private Button _addRowButton;
    [SerializeField] private Button _removeRowButton;

    private UIFactory _uIFactory;
    private List<TablePreviewItem> _tablePreviewItems;
    private TablePreviewItem _selectedTablePreviewItem;

    public void Init(UIFactory uIFactory)
    {
        _uIFactory = uIFactory;
    }

    public void AddRow(ModelViewObjectPreview modelViewObjectPreview)
    {
        TablePreviewItem item = _uIFactory.Create(modelViewObjectPreview, _tableContainer);
        item.OnSelectTableItem += OnSelectTableItem;
        _tablePreviewItems.Add(item);
    }

    public void Setup(ModelViewObjectPreview[] modelsPreview)
    {
        _tablePreviewItems = new List<TablePreviewItem>(modelsPreview.Length);

        _addRowButton.onClick.AddListener(TapAddRowButton);
        _removeRowButton.onClick.AddListener(TapRemoveRowButton);

        foreach (var model in modelsPreview)
        {
            AddRow(model);
        }
    }

    private void TapRemoveRowButton()
    {
        if (_selectedTablePreviewItem == default)
        {
            return;
        }

        RemoveRowItem(_selectedTablePreviewItem);
    }

    private void RemoveRowItem(TablePreviewItem selectedTablePreviewItem)
    {
        _tablePreviewItems.Remove(selectedTablePreviewItem);

        for (int index = 0; index < _tableContainer.childCount; index++)
        {
            if (_tableContainer.GetChild(index).TryGetComponent(out TablePreviewItem tablePreviewItem) && tablePreviewItem.ID == selectedTablePreviewItem.ID)
            {
                Destroy(_tableContainer.GetChild(index).gameObject);
            }
        }
    }

    private void TapAddRowButton()
    {
        OnTapAddRowButton?.Invoke();
    }

    private void OnSelectTableItem(TablePreviewItem tablePreviewItem)
    {
        _selectedTablePreviewItem = tablePreviewItem;
        OnSelectRow?.Invoke(tablePreviewItem.ID);
    }
}
