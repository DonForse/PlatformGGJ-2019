using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class House : MonoBehaviour
{
    public Sprite[] Sprites;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void Change(PickupItem.KeyItem item)
    {
        switch (item)
        {
            case PickupItem.KeyItem.Fences:
                sr.sprite = Sprites[1];
                break;
            case PickupItem.KeyItem.Wood:
                sr.sprite = Sprites[2];
                break;
            case PickupItem.KeyItem.Courtains:
                sr.sprite = Sprites[3];
                break;
            default:
                break;
        }
    }
}
