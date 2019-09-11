using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public enum KeyItem {
        Fences = 1,
        Wood = 2,
        Courtains = 3,
    }

    public KeyItem Item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null && collision.gameObject.layer == (int)NameIndex.Layers.Player)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PickupItem(this.Item);
            
            Destroy(this.gameObject);
        }
    }
}
