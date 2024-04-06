using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<PlayerHealth> players = new List<PlayerHealth>();

    private void Awake()
    {
        instance = this;
    }

    public void AddPlayer(PlayerHealth player)
    {
        players.Add(player);
    }
}
