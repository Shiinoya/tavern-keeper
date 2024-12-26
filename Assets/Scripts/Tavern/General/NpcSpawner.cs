using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject npcUnit;

    public void Start()
    {
        // spawn NPC every five seconds; TODO : make this vary
        InvokeRepeating("SpawnNpc", 5f, 5f);
    }

    public void SpawnNpc()
    {
        Vector2 spawnPosition = new Vector2(0f, -4.2f);

        Instantiate(npcUnit, spawnPosition,Quaternion.identity);
    }

    // TODO : public void MoveNpc() {
    // move npc towards random position and later onto empty tables
    //}
}
