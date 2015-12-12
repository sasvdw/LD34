using UnityEngine;

public class MapLoader : MonoBehaviour {

    public string mapFile;

    public GameObject floor;

    private Transform boardHolder; // Contains all the GameObjects used for rendering
    private string[] mapTileNames;

	void Start () {
        mapTileNames = loadMap();

        // TODO: Post process map to make nicer borders between terrain types

        renderMap();
    }
	
	void Update () {
	}

    private string[] loadMap() {
        Debug.Log(System.Environment.Version);
        string[] result = new string[MapConstants.WIDTH * MapConstants.HEIGHT];
        char[] data = System.Text.Encoding.ASCII.GetString(System.IO.File.ReadAllBytes(mapFile)).ToCharArray();
        data = filterData(data);

        for (int y = 0; y < MapConstants.HEIGHT; y++) {
            for (int x = 0; x < MapConstants.WIDTH; x++) {
                int idx = calcMapIndex(x, y);

                char mapChar = data[idx];
                string tileName;
                MapConstants.tileMap.TryGetValue(mapChar, out tileName);
                if (tileName == null) {
                    tileName = "dirt";
                }
                result[idx] = tileName;
            }
        }

        return result;
    }

    private char[] filterData(char[] data) {
        char[] dataFiltered = new char[data.Length];

        int insertPos = 0;
        for (int i = 0; i < data.Length; i++) {
            if (MapConstants.tileMap.ContainsKey(data[i])) {
                dataFiltered[insertPos++] = data[i];
            }
        }

        return dataFiltered;
    }

    private void renderMap() {
        boardHolder = new GameObject().transform;

        for (int y = 0; y < MapConstants.HEIGHT; y++) {
            for (int x = 0; x < MapConstants.WIDTH; x++) {
                GameObject instance = Instantiate(floor, new Vector3(x, MapConstants.HEIGHT - y - 1, 0f), Quaternion.identity) as GameObject;
                SpriteRenderer renderer = instance.GetComponent<SpriteRenderer>();
                renderer.sprite = SpriteRepository.GetSpriteByName(mapTileNames[calcMapIndex(x, y)]);
                instance.transform.SetParent(boardHolder);
            }
        }
    }

    private int calcMapIndex(int x, int y) {
        return y * MapConstants.WIDTH + x;
    }
}
