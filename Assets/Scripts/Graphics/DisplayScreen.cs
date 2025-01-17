using System.Drawing;
using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Color = UnityEngine.Color;

public class DisplayScreen : BuiltinChip
{
    public Renderer textureRender;
    public const int SIZE = 8;
    private string editCoords;
    Texture2D texture;
    int[] texCoords;

    public static Texture2D CreateSolidTexture2D(Color color, int width, int height = -1) {
        if(height == -1) {
            height = width;
        }
        Texture2D texture = new Texture2D(width, height);
        Color[] pixels = Enumerable.Repeat(color, width * height).ToArray();
        texture.SetPixels(pixels);
        texture.Apply();
        return texture;
    }

    public int[] map2d(int index, int size) {
        int[] coords = new int[2];
        coords[0] = index % size;
        coords[1] = index / size;
        return coords;
    }

	protected override void Awake()
	{
        texture = CreateSolidTexture2D(new Color(0, 0, 0), SIZE);
        texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
        textureRender.sharedMaterial.mainTexture = texture;
		base.Awake();
        category = ChipCategory.Custom;
	}



    //update display here
	protected override void ProcessOutput() {
        editCoords = "";
        for(int i = 6; i < 12; i++) {
            editCoords += inputPins[i].State.ToString();
        }
        texCoords = map2d(Convert.ToInt32(editCoords, 2), SIZE);
        texture.SetPixel(texCoords[0], texCoords[1], new Color(Convert.ToInt32(inputPins[0].State.ToString() + inputPins[1].State.ToString(), 2) / 2f, Convert.ToInt32(inputPins[2].State.ToString() + inputPins[3].State.ToString(), 2) / 2f, Convert.ToInt32(inputPins[4].State.ToString() + inputPins[5].State.ToString(), 2)) / 2f);
        texture.Apply();
    }
}