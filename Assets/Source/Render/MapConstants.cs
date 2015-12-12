using UnityEngine;
using System.Collections.Generic;

public class MapConstants {

    public const int WIDTH = 40;
    public const int HEIGHT = 30;

    private static Dictionary<char, string> surfaceMap = new Dictionary<char, string>();
    private static Dictionary<char, string> dungeonMap = new Dictionary<char, string>();

    public static Dictionary<char, string> GetTileSet(TileSet tileSet) {
        if (tileSet == TileSet.SURFACE) {
            return surfaceMap;
        } else if (tileSet == TileSet.DUNGEON) {
            return dungeonMap;
        } else {
            return surfaceMap;
        }
    }

    public enum TileSet { SURFACE, DUNGEON }

    static MapConstants() {
        surfaceMap.Add('.', "dirt");
        surfaceMap.Add(',', "grass");

        dungeonMap.Add('.', "dungeondirt");
        dungeonMap.Add(',', "dungeon");
    }
}
