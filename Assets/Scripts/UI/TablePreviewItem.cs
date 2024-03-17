using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TablePreviewItem : MonoBehaviour
{
    public event Action<TablePreviewItem> OnSelectTableItem;

    [SerializeField] private TextMeshProUGUI _idText;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Button _selectButton;

    private string _id;

    public string ID => _id;

    public void Setup(ModelViewObjectPreview model)
    {
        _id = model.ID;
        _idText.text = model.ID;
        _nameText.text = model.Name;
    }

    private void Start()
    {
        _selectButton.onClick.AddListener(TapSelectButton);
    }

    private void TapSelectButton()
    {
        OnSelectTableItem?.Invoke(this);
    }
}