using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : Jam
{
    float fallZone = -10f;
    public Transform playerSpawnPoint;

    void Update(){
        if(this.game.player.transform.position.y < this.fallZone) {
            this.game.player.transform.position = this.playerSpawnPoint.position;
        }
    }
}
