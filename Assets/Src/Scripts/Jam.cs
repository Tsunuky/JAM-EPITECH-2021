using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Jam : MonoBehaviour
{
    private static Game _game;
    protected Game game => this.getGame();
    Game getGame() {
        if (_game != null) return _game;
        foreach (GameObject go in SceneManager.GetActiveScene().GetRootGameObjects()) {
            _game = go.GetComponentInChildren<Game>();
            if (_game != null) return _game;
        }
        return null;
    }
}
