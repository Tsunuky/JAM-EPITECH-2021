using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : Jam {

    public void Dead() {
        Destroy(gameObject);
    }
}
