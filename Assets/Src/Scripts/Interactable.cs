using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Jam {
    
    
    [SerializeField]
    float radius = 3f;
    [SerializeField]
    Transform interactionTransform;
    bool hasInteract = false;

    void Start() {

    }
    public virtual void Interact() {
        Debug.Log("Interacting with" + this.transform.name);
    }
    public virtual void QuitInteract() {
        Debug.Log("Stop interacting with" + this.transform.name);
    }

    void Update()
    {
        float distance = Vector3.Distance(this.game.player.transform.position, this.interactionTransform.position);
        if (distance <= this.radius) {
            this.Interact();
            this.hasInteract = true;
        }
        if (distance > this.radius && this.hasInteract) {
            this.QuitInteract();
            this.hasInteract = false;
        }
        
    }

    void OnDrawGizmosSelected() {
        if (this.interactionTransform == null)
            this.interactionTransform = this.transform;
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.interactionTransform.position, this.radius);
    }
}
