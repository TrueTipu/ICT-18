using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inventory : MonoBehaviour
{

    [SerializeField]List<Slot> slots = new List<Slot>();
    [SerializeField] List<bool> isFull = new List<bool>();

    int max = 3;

    public bool CheckMax() //toistainen max, katsotaan tarvitaanko mihin ja kuin paljon
    {
        return isFull.Count >= max;
    }

    public void AddItem(Item item)
    {
        Debug.Log("true");
        int i = isFull.Count;
        FillSlot(slots[i], item);
        isFull.Add(true);
    }

    public void RemoveItem(int index)
    {
        isFull[index] = false;
        Destroy(slots[index].item.gameObject); //vaiha EHKÄ ? järkevämmäks



        for (int i = 0; i < isFull.Count - 1; i++)
        {
            if (isFull[i] == false)
            {
                isFull[i + 1] = false;
                FillSlot(slots[i], slots[i + 1].item.itemData);
                Destroy(slots[i + 1].item.gameObject);
                isFull[i] = true;
            }
        }
        isFull.RemoveAt(isFull.Count - 1);
    }

    void FillSlot(Slot slot, Item item)
    {
        InvItem invItem = Instantiate(item.GetItemHold(), slot.transform, false).GetComponent<InvItem>();
        invItem.itemData = item;
        slot.item = invItem;
    }

}

