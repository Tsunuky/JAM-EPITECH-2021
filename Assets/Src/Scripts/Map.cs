using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Jam
{
    [SerializeField]
    Game.Dimension _defaultDimension;
    [SerializeField]
    GameObject past;
    [SerializeField]
    GameObject present;
    [SerializeField]
    GameObject future;
    [SerializeField]
    GameObject pastAndPresent;
    [SerializeField]
    GameObject pastAndFuture;
    [SerializeField]
    GameObject presentAndFuture;
    [SerializeField]
    Transform _defaultPosition;
    
    public Game.Dimension defaultDimension => this._defaultDimension;
    public Transform defaultPosition => this._defaultPosition;
    private void Awake() {
        this.game.OnDimensionChange += this.OnDimensionChange;
        this.OnDimensionChange(this.game.dimension);
    }
    private void OnDestroy() {
        if (this.game) {
            this.game.OnDimensionChange -= this.OnDimensionChange;
        }
    }

    public void Activate() {
        gameObject.SetActive(true);
    }
    public void Desactivate() {
        gameObject.SetActive(false);
    }
    void OnDimensionChange(Game.Dimension dimension) {
        this.past.SetActive(dimension == Game.Dimension.Past);
        this.present.SetActive(dimension == Game.Dimension.Present);
        this.future.SetActive(dimension == Game.Dimension.Future);
        if (this.pastAndPresent != null) {
            this.pastAndPresent.SetActive(dimension != Game.Dimension.Future);
        }
        if (this.pastAndFuture != null) {
            this.pastAndFuture.SetActive(dimension != Game.Dimension.Present);
        }
        if (this.presentAndFuture != null) {
            this.presentAndFuture.SetActive(dimension != Game.Dimension.Past);
        }
    }
}
