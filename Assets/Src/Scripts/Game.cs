using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Jam
{
    public enum Dimension {
        Past,
        Present,
        Future
    };
    [SerializeField]
    Dimension _dimension;
    public Player player;
    [SerializeField]
    Map _map;
    [SerializeField]
    DialogueManager _dialogueManager;
    public DialogueManager dialogueManager => this._dialogueManager;
    public delegate void DimensionHandler(Dimension dimension);
    public event DimensionHandler OnDimensionChange;
    public Dimension dimension
    {
        get => this._dimension;
        set {
            if (this.OnDimensionChange != null) {
                this.OnDimensionChange(value);
            }
            this._dimension = value;
        }
    }

    public void ChangeMap(Map newMap) {
        if (this._map != null) {
            Destroy(this._map.gameObject);
            this._map = null;
        }
        this.dimension = newMap.defaultDimension;
        this._map = Instantiate(newMap, this.transform);
        this._map.Activate();
        this.player.transform.position = this._map.defaultPosition.position;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            this.dimension = Dimension.Past;
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            this.dimension = Dimension.Present;
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            this.dimension = Dimension.Future;
        }
    }
}
