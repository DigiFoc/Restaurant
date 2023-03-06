using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quantityInfo : MonoBehaviour
{
    int quantity;
    public void AddQuantity(int incomingQuantity)
    {
        quantity = quantity+incomingQuantity;
    }
}
