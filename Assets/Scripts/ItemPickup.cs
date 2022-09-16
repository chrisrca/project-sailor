using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease
    }

    public ItemType type;
    public AudioSource appear;
    public AudioClip pickUp;

    private void OnItemPickup(GameObject player)
    {
        
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                appear.Play();
                break;

            case ItemType.BlastRadius:
                player.GetComponent<BombController>().explosionRadius++;
                appear.Play();
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().speed++;
                appear.Play();
                break;
        }
        AudioSource.PlayClipAtPoint(pickUp, transform.position);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnItemPickup(other.gameObject);
        }
    }
}
