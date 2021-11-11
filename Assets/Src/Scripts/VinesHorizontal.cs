using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinesHorizontal : Jam
{
    private void OnTriggerEnter2D(Collider2D collision) {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb == null || rb.CompareTag("Player") == false) return;
        this.game.player.canUseVines = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb == null || rb.CompareTag("Player") == false) return;
        this.game.player.canUseVines = false;
    }
}
