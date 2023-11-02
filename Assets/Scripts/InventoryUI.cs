using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour

{
    private TextMeshProUGUI BrainText;

    // Start is called before the first frame update
    void Start()
    {
        BrainText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateBrainText(PlayerInventory playerInventory)
    {
        BrainText.text = playerInventory.NumberOfBrains.ToString();
    }
}
