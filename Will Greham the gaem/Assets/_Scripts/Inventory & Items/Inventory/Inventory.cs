using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;


public class Inventory : MonoBehaviour
{

    [SerializeField]List<Slot> slots = new List<Slot>();
    [SerializeField] List<bool> isFull = new List<bool>();

    int max = 10;

    public Action<Item> ItemAdded;
    public Action<int> ItemRemoved;

    private void Awake()
    {
        CycleCalculator calculator = GetComponent<CycleCalculator>();
        slots = new List<Slot>(calculator.GetSlots());

        ItemAdded += AddItem;
        ItemAdded += calculator.Increase;

        ItemRemoved += RemoveItem;
        ItemRemoved += calculator.Decrease;
    }

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
        InvItem invItem = Instantiate(item.GetItemHold(), slot.SlotPos, false).GetComponent<InvItem>();
        invItem.itemData = item;
        slot.item = invItem;
    }

    private void Update()
    {
        if(isFull.Count > 0) ClosestItem();
    }
    void ClosestItem()
    {
        float _dis = Vector2.Distance(slots[0].SlotPos.position, Input.mousePosition);
        int _index = 0;
        slots[0].isPointed = false;
        for (int i = 1; i < isFull.Count; i++)
        {
            float _newDis = Vector2.Distance(slots[i].SlotPos.position, Input.mousePosition);
            if (_dis > _newDis)
            {
                _dis = _newDis;
                _index = i;
            }
            slots[i].isPointed = false;
        }
        slots[_index].isPointed = true;

    }

}

