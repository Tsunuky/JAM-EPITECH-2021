using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : Jam {
    [SerializeField]
    Character past;
    [SerializeField]
    Character present;
    [SerializeField]
    Character future;
    bool _isGrounded = false;

    public Transform firePoint;
    public GameObject bullet;
    bool isGrounded
    {
        get => this._isGrounded;
        set
        {
            this.past.animator.SetBool("isGrounded", value);
            this.present.animator.SetBool("isGrounded", value);
            this.future.animator.SetBool("isGrounded", value);
            this._isGrounded = value;
        }
    }
    [HideInInspector()]
    public bool canUseVines = false;
    Rigidbody2D rb;
    bool _useVines = false;
    bool useVines
    {
        get => this._useVines;
        set
        {
            this.rb.gravityScale = value ? 0.0f : 1.0f;
            this._useVines = value;
        }
    }
    private void Awake() {
        this.game.OnDimensionChange += this.OnDimensionChange;
        this.OnDimensionChange(this.game.dimension);
        this.rb = this.GetComponent<Rigidbody2D>();
    }
    private void OnDestroy() {
        if (this.game) {
            this.game.OnDimensionChange -= this.OnDimensionChange;
        }
    }

    void OnDimensionChange(Game.Dimension dimension) {
        this.past.SetActive(dimension == Game.Dimension.Past);
        this.present.SetActive(dimension == Game.Dimension.Present);
        this.future.SetActive(dimension == Game.Dimension.Future);
    }

    Character currentCharacter
    {
        get
        {
            switch (this.game.dimension) {
                case Game.Dimension.Past: return this.past;
                case Game.Dimension.Present: return this.present;
                case Game.Dimension.Future: return this.future;
            }
            return null;
        }
    }

    float dir = 1.0f;
    Tween tweenPast;
    Tween tweenPresent;
    Tween tweenFuture;

    private void Start() {
        Vector3 rotation = Vector3.up * this.dir * 90.0f;
        this.past.baseTransform.eulerAngles = rotation;
        this.present.baseTransform.eulerAngles = rotation;
        this.future.baseTransform.eulerAngles = rotation;
    }
    void Update() {
        float move = Input.GetAxis("Horizontal");
        this.past.walk = Mathf.Abs(move);
        this.present.walk = Mathf.Abs(move);
        this.future.walk = Mathf.Abs(move);
        float newDir = Mathf.Sign(move);
        if (this.dir != newDir && move != 0.0f) {
            if (this.tweenPast != null) {
                this.tweenPast.Kill();
            }
            if (this.tweenPresent != null) {
                this.tweenPresent.Kill();
            }
            if (this.tweenFuture != null) {
                this.tweenFuture.Kill();
            }
            Vector3 rotation = Vector3.up * newDir * 90.0f;
            this.tweenPast = this.past.baseTransform.DORotate(rotation, 0.5f);
            this.tweenPresent = this.present.baseTransform.DORotate(rotation, 0.5f);
            this.tweenFuture = this.future.baseTransform.DORotate(rotation, 0.5f);
            this.dir = newDir;
        }
        if (Input.GetButtonDown("Fire1") && this.game.dimension == Game.Dimension.Future) {
            Shooting();
        }
        this.transform.position += Vector3.right * move * this.currentCharacter.speed * Time.deltaTime;
        //TODO: IMPROVE
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (this.useVines) {
            this.isGrounded = true;
        }
        if (Input.GetButtonDown("Jump") && this.isGrounded) {
            this.rb.AddForce(new Vector3(0, this.currentCharacter.playerUpwardForce, 0), ForceMode2D.Impulse);
            this.isGrounded = false;
            this.currentCharacter.animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.K) && this.canUseVines && this.game.dimension == Game.Dimension.Past && this.useVines == false) {
            this.useVines = true;
            this.rb.velocity = Vector3.zero;
        }
        if (this.useVines && (this.canUseVines == false || this.game.dimension != Game.Dimension.Past || Input.GetKeyDown(KeyCode.S))) {
            this.useVines = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.isTrigger == false) {
            this.isGrounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.isTrigger == false) {
            this.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.isTrigger == false) {
            this.isGrounded = false;
        }
    }
    void Shooting() {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        this.currentCharacter.animator.SetTrigger("Shoot");
        Debug.Log("Shoot");
    }
}