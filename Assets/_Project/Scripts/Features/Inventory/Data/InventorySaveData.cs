using System.Collections.Generic;
using System;

namespace Project.Features.Inventory.Data
{
    [Serializable]
    public class InventorySaveData
    {
        public List<SlotSaveData> inventoryItems = new List<SlotSaveData>();
    }
    
    [Serializable]
    public struct SlotSaveData
    {
        public string itemID;
        public int quantity;
        public int slotIndex;
    }
}
