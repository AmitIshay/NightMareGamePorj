using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 300f;
    [SerializeField] Transform teleportDestination; // Add a reference to the teleport destination
    [SerializeField] GameObject playerGameObject; // Add a reference to the player GameObject
    DisplayLive displayLive;

    void Start()
    {
        displayLive = FindObjectOfType<DisplayLive>(); // Initialize the displayLive reference
    }
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints == 200f || hitPoints == 100f)
        {
            TeleportPlayer(); // Call the teleportation method
            displayLive.ShowDamageImpactt();
        }
        if (hitPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
        private void TeleportPlayer()
    {
        // Instantiate the teleport class and call the teleportation method
        teleport teleporter = new teleport();
        teleporter.player = this.transform;
        teleporter.destination = teleportDestination;
        teleporter.playerg = playerGameObject;
        teleporter.TeleportToDestination();
    }
}
