using UnityEngine;
using System.Collections.Generic;

public class SpriteRepository {

    private static Dictionary<string, Sprite> sprites;

    public static Sprite GetSpriteByName(string name) {
        Debug.Log("Loading sprite: '" + name + "'.");
        Sprite result;
        sprites.TryGetValue(name, out result);

        if (result == null) {
            sprites.TryGetValue(name.Split('-')[0], out result);
        }

        return result;
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
