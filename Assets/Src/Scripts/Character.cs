using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public float speed;
    [SerializeField]
    public Transform baseTransform;
    [SerializeField]
    public float playerUpwardForce;
    public Renderer[] renderers;
    public Collider2D[] collider2Ds;

    public float walk
    {
        get => this.animator.GetFloat("Walk");
        set => this.animator.SetFloat("Walk", value);
    }

    private void Awake() {
        this.renderers = this.GetComponentsInChildren<Renderer>();
        this.collider2Ds = this.GetComponentsInChildren<Collider2D>();
    }

    public void SetActive(bool value) {
        foreach (Renderer renderer in this.renderers) {
            renderer.enabled = value;
        }
        foreach (Collider2D collider2D in this.collider2Ds) {
            collider2D.enabled = value;
        }
    }
}
