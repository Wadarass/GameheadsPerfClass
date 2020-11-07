using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnEnable()
    {
        CoverManager.Instance.RegisterCover(this);
    }

    public void OnDisable()
    {
        CoverManager.Instance.DeregisterCover(this);
    }
}
