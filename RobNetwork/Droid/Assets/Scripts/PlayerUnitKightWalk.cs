using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/* This script is controlled by a player */
public class PlayerUnitKightWalk : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // This function runs on ALL PlayerUnits, not just the one owned by the running device
        
        // How do we verify that we're allowed to mess around with this object?
        
        if (!hasAuthority)
        {
            // This object belongs to another player
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.Translate(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
        }

    }
}
     