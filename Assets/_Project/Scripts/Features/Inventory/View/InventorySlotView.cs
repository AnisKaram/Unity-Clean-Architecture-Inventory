using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Project.Features.Inventory.View
{
    /// <summary>
    /// This creates a wrapper for the UI inventory button prefab.
    /// </summary>
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private Image m_Icon;
        [SerializeField] private Button m_SlotButton;
        [SerializeField] private TextMeshProUGUI m_QuantityText;

        private void OnDestroy()
        {
            m_SlotButton.onClick.RemoveAllListeners();
        }
        
        public void Initialize(int index, Action<int> onClick)
        {
            int clickIndex = index;
            m_SlotButton.onClick.AddListener(() => onClick(clickIndex));
        }

        public void SetData(Sprite icon, int quantity)
        {
            // Empty Slot
            if (icon == null)
            {
                m_Icon.gameObject.SetActive(false);
                m_QuantityText.gameObject.SetActive(false);
                return;
            }
            
            // Valid item
            m_Icon.gameObject.SetActive(true);
            m_Icon.sprite = icon;
            
            // Show the text if quantity is 2+ 
            bool isStack = quantity > 1;
            m_QuantityText.gameObject.SetActive(isStack);
            if (isStack)
            {
                m_QuantityText.text = quantity.ToString();
            }
        }
    }
}
