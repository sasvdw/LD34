using UnityEngine;
using System.Collections.Generic;

public class MapLoader : MonoBehaviour {

    public string mapFile;

    public GameObject floor;

    private Transform boardHolder; // Contains all the GameObjects used for rendering
    private string[] mapTileNames;
    private int[] surroundingPositionValues = { 1, 2, 4, 8, 0, 16, 32, 64, 128 };
    private static Dictionary<int, string> positionIdsToNames;
    private Dictionary<char, string> tileSet;
    private string primary;
    private string secondary;

	void Start () {
        tileSet = MapConstants.GetTileSet(MapConstants.TileSet.SURFACE);
        primary = tileSet['.'];
        secondary = tileSet[','];

        mapTileNames = loadMap();

        prettifyTerrainEdges();

        renderMap();
    }
	
	void Update () {
	}

    private string[] loadMap() {
        Debug.Log(System.Environment.Version);
        string[] result = new string[MapConstants.WIDTH * MapConstants.HEIGHT];

        TextAsset textFile = Resources.Load<TextAsset>(mapFile);
        char[] data = System.Text.Encoding.ASCII.GetString(textFile.bytes).ToCharArray();
        data = filterData(data);

        for (int y = 0; y < MapConstants.HEIGHT; y++) {
            for (int x = 0; x < MapConstants.WIDTH; x++) {
                int idx = calcMapIndex(x, y);

                char mapChar = data[idx];
                string tileName;
                tileSet.TryGetValue(mapChar, out tileName);
                if (tileName == null) {
                    tileName = primary;
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
            if (tileSet.ContainsKey(data[i])) {
                dataFiltered[insertPos++] = data[i];
            }
        }

        return dataFiltered;
    }

    private void prettifyTerrainEdges() {
        for (int y = 0; y < MapConstants.HEIGHT; y++) {
            for (int x = 0; x < MapConstants.WIDTH; x++) {
                string tile = mapTileNames[calcMapIndex(x, y)];
                if (tile.Equals(secondary)) {
                    int positionId = 0;

                    for (int yy = -1; yy <= 1; yy++) {
                        for (int xx = -1; xx <= 1; xx++) {
                            if (yy == 0 && xx == 0) continue;

                            int idx = calcMapIndex(x + xx, y + yy);
                            string tileName = (idx < 0 || idx >= mapTileNames.Length) ? secondary : mapTileNames[idx];
                            string[] tileNameParts = tileName.Split('-');
                            if (tileNameParts[0].Equals(primary)) {
                                int positionIdx = (yy + 1) * 3 + (xx + 1);
                                positionId += surroundingPositionValues[positionIdx];
                            }
                        }
                    }

                    if (positionId > 0) {
                        string extension;
                        positionIdsToNames.TryGetValue(positionId, out extension);

                        if (extension != null && !extension.Equals("")) {
                            mapTileNames[calcMapIndex(x, y)] = secondary + "-" + primary + extension;
                        }
                    }
                }
            }
        }
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

    static MapLoader() {
        positionIdsToNames = new Dictionary<int, string>();

        // Use full tile
        positionIdsToNames.Add(0, "");

        // Use custom tiles...
        positionIdsToNames.Add(11, "-nw");
        positionIdsToNames.Add(15, "-nw");
        positionIdsToNames.Add(43, "-nw");
        positionIdsToNames.Add(47, "-nw");

        positionIdsToNames.Add(2, "-n");
        positionIdsToNames.Add(3, "-n");
        positionIdsToNames.Add(6, "-n");
        positionIdsToNames.Add(7, "-n");

        positionIdsToNames.Add(22, "-ne");
        positionIdsToNames.Add(23, "-ne");
        positionIdsToNames.Add(150, "-ne");
        positionIdsToNames.Add(151, "-ne");

        positionIdsToNames.Add(16, "-e");
        positionIdsToNames.Add(20, "-e");
        positionIdsToNames.Add(144, "-e");
        positionIdsToNames.Add(148, "-e");

        positionIdsToNames.Add(208, "-se");
        positionIdsToNames.Add(212, "-se");
        positionIdsToNames.Add(240, "-se");
        positionIdsToNames.Add(244, "-se");

        positionIdsToNames.Add(64, "-s");
        positionIdsToNames.Add(96, "-s");
        positionIdsToNames.Add(192, "-s");
        positionIdsToNames.Add(224, "-s");

        positionIdsToNames.Add(104, "-sw");
        positionIdsToNames.Add(105, "-sw");
        positionIdsToNames.Add(232, "-sw");
        positionIdsToNames.Add(233, "-sw");

        positionIdsToNames.Add(8, "-w");
        positionIdsToNames.Add(9, "-w");
        positionIdsToNames.Add(40, "-w");
        positionIdsToNames.Add(41, "-w");

        positionIdsToNames.Add(31, "-top");
        positionIdsToNames.Add(63, "-top");
        positionIdsToNames.Add(159, "-top");
        positionIdsToNames.Add(191, "-top");

        positionIdsToNames.Add(248, "-bottom");
        positionIdsToNames.Add(249, "-bottom");
        positionIdsToNames.Add(252, "-bottom");
        positionIdsToNames.Add(253, "-bottom");

        positionIdsToNames.Add(107, "-left");
        positionIdsToNames.Add(111, "-left");
        positionIdsToNames.Add(235, "-left");
        positionIdsToNames.Add(239, "-left");

        positionIdsToNames.Add(214, "-right");
        positionIdsToNames.Add(215, "-right");
        positionIdsToNames.Add(246, "-right");
        positionIdsToNames.Add(247, "-right");

        positionIdsToNames.Add(189, "-vertical");
        positionIdsToNames.Add(231, "-horizontal");

        positionIdsToNames.Add(255, "-alone");
    }
}
