using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enumerator;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
    public Type type;
    public bool isOccupied;

    public Image tileImage;

    public void SetImage(Sprite sprite) {
        tileImage.sprite = sprite;
    }

    public void Occupy(Type type, Sprite sprite) {
        this.type = type;
        SetImage(sprite);
    }

    public void unOccupy() {
        isOccupied = false;
        SetImage(null);
        type = Type.Default;
    }

}
