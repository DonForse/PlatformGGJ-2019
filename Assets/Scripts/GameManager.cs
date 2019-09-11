using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public SoundManager soundManager;

    public House House;

    public Transform[] respawnsPositions;
    public Transform currentRespawnPosition;

    public void KillPlayer() {
        player.Respawn(currentRespawnPosition);
    }

    public void PickupItem(PickupItem.KeyItem item) {
        switch (item)
        {
            case global::PickupItem.KeyItem.Fences:
                currentRespawnPosition = respawnsPositions[1];
                break;
            case global::PickupItem.KeyItem.Wood:
                currentRespawnPosition = respawnsPositions[2];
                break;
            case global::PickupItem.KeyItem.Courtains:
                currentRespawnPosition = respawnsPositions[3];
                break;
            default:
                break;
        }
        soundManager.PlayPickupItemClip();
        House.Change(item);
    }
}
