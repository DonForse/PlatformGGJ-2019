using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Respawn(Transform respawnPosition) {
        this.transform.position = respawnPosition.position;
    }
}
