using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    static int xAmount = 100;
    static int yAmount = 20;
    static float spacing = 5.0f;

    [MenuItem("Gameheads/SpawnCover")]
    static public void CreateCoverObjects()
    {
        GameObject cover = AssetDatabase.LoadAssetAtPath("Assets/CoverObject.prefab", typeof(GameObject)) as GameObject;

        for(int i = 0; i < xAmount; i++)
        {
            for (int j = 0; j < yAmount; j++)
            {
                Vector3 pos = new Vector3(i * spacing, 0.5f, j * spacing);

                GameObject.Instantiate(cover, pos, Quaternion.identity);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestCover(); 
    }

    private void FindClosestCover()
    {
        CoverManager.Instance.FindClosestCover(this);
    }
}
