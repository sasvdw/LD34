using UnityEngine;
using System.Collections.Generic;

public class MapConstants {

    public const int WIDTH = 40;
    public const int HEIGHT = 30;
    public static Dictionary<char, string> tileMap = new Dictionary<char, string>();

    static MapConstants() {
        tileMap.Add('.', "dirt");
        tileMap.Add(',', "grass");
    }
}
