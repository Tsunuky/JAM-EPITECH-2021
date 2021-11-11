using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevel : Jam
{
    [SerializeField]
    Map map;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.isTrigger == false && collision.attachedRigidbody != null && collision.attachedRigidbody.CompareTag("Player") && this.map != null) {
            this.game.ChangeMap(this.map);
        }
    }

}
