using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;
        if (collision.gameObject.layer == (int)NameIndex.Layers.Player)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().KillPlayer();
        }
    }
}
