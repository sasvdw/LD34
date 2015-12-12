using UnityEngine;

public class SwitchTileset : MonoBehaviour {

    private MapLoader mapLoader;

    void Start() {
        mapLoader = FindObjectOfType<MapLoader>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            mapLoader.toggleTileType();
        }
    }
}
