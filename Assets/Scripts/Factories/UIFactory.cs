using UnityEngine;

public class UIFactory
{
    private TablePreviewItem _tablePreviewItemPrefab;

    public UIFactory(TablePreviewItem tablePreviewItemPrefab)
    {
        _tablePreviewItemPrefab = tablePreviewItemPrefab;
    }

    public TablePreviewItem Create(ModelViewObjectPreview model, RectTransform parent)
    {
        TablePreviewItem item = Object.Instantiate(_tablePreviewItemPrefab, parent);
        item.Setup(model);
        return item;
    }
}