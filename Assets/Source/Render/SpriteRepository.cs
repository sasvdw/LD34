using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SpriteRepository {

    private static Dictionary<string, Sprite> sprites;

    public static Sprite GetSpriteByName(string name) {
        return sprites[name];
    }

    static SpriteRepository() {
        sprites = new Dictionary<string, Sprite>();

        Sprite[] allSprites = Resources.LoadAll<Sprite>("Tiles");
        for (int i = 0; i < allSprites.Length; i++) {
            Sprite sprite = allSprites[i];

            if (sprite.name.Contains("_")) continue; // Filter out sprites that we have not manually named

            sprites.Add(sprite.name, sprite);
        }
    }
}
