using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public delegate void OnGrounded(bool grounded);
    public event OnGrounded Grounded;

    public delegate void OnMovingPlatform(bool on, GameObject go);
    public event OnMovingPlatform MovingPlatform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;

        else if (collision.gameObject.layer >= (int)NameIndex.Layers.Terrain)
            Grounded(true);

        else if (collision.gameObject.layer == (int)NameIndex.Layers.MovingPlatforms)
            MovingPlatform(true, collision.gameObject);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;
        else if (collision.gameObject.layer >= (int)NameIndex.Layers.Terrain)
            Grounded(false);
        else if (collision.gameObject.layer == (int)NameIndex.Layers.MovingPlatforms)
            MovingPlatform(false, null);
    }
}
