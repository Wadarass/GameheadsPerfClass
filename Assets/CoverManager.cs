using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverManager
{
    const int GRID_SIZE = 10;
    private static CoverManager instance = null;

    private CoverManager()
    {
    }

    public static CoverManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CoverManager();
            }
            return instance;
        }
    }

    public Dictionary<int, List<PlayerCover>> covers = new Dictionary<int, List<PlayerCover>>();

    private int HashPosition(Transform point)
    {
        int bucketX = (int)(point.position.x / GRID_SIZE);
        int bucketY = (int)(point.position.z / GRID_SIZE);

        int bucketValue = bucketX + bucketY * GRID_SIZE;

        return bucketValue;
    }

    public void RegisterCover(PlayerCover cover)
    {
        int bucketValue = HashPosition(cover.transform);

        List<PlayerCover> list = null;

        if (!covers.TryGetValue(bucketValue, out list))
        {
            list = new List<PlayerCover>();
            covers.Add(bucketValue, list);
        }
        list.Add(cover);
    }

    public void DeregisterCover(PlayerCover cover)
    {
        int bucketValue = HashPosition(cover.transform);

        covers[bucketValue].Remove(cover);
    }

    public void FindClosestCover(Player player)
    {
       float closestDistance = float.MaxValue;
        PlayerCover closestObject = null;

        int bucketValue = HashPosition(player.transform);
        List<PlayerCover> playerList = null;

        if (!covers.TryGetValue(bucketValue, out playerList))
        {
            return;
        }

        foreach (PlayerCover cover in playerList)
        {
             float distance = Vector3.Distance(cover.transform.position, player.transform.position);
             if (distance < closestDistance)
             {
                 closestDistance = distance;
                 closestObject = cover;
             }
         }

        Debug.DrawLine(player.transform.position, closestObject.transform.position);
    }
}
