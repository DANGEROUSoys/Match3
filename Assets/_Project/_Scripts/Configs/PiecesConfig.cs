using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
public enum Shapes
{
    Square,
    Sircle,
    Triangle
}
public enum Animals
{
    Raccoon,
    Hare,
    Panda,
    Owl,
    Koala,
    Cow,
    Lion,
    Giraffe
}
public enum Colors
{
    Blue,
    Green,
    Turquoise,
    Purple,
    Pink,
    White
}

public class PiecesConfig
{
    public Dictionary<Shapes, GameObject> ShapesDictionary = new Dictionary<Shapes, GameObject>();
    public Dictionary<Animals, Sprite> AnimalsDictionary = new Dictionary<Animals,Sprite>();
    public Dictionary<Colors, Color> ColorsDictionary = new Dictionary<Colors, Color>();

    public PiecesConfig()
    {
        AddShapesInDictionary();
        AddAnimalsInDictionary();
        AddColorsInDictionray();
    }

    private void AddShapesInDictionary()
    {
        ShapesDictionary.Add(Shapes.Triangle, Resources.Load("Prefabs/TrianglePiece") as GameObject);
        ShapesDictionary.Add(Shapes.Square, Resources.Load("Prefabs/SquarePiece") as GameObject);
        ShapesDictionary.Add(Shapes.Sircle, Resources.Load("Prefabs/CirclePiece") as GameObject);
    }

    private void AddAnimalsInDictionary()
    {
        AnimalsDictionary.Add(Animals.Raccoon, Resources.Load<Sprite>("Sprites/Raccoon"));
        AnimalsDictionary.Add(Animals.Hare, Resources.Load<Sprite>("Sprites/Hare"));
        AnimalsDictionary.Add(Animals.Panda, Resources.Load<Sprite>("Sprites/Panda"));
        AnimalsDictionary.Add(Animals.Owl, Resources.Load<Sprite>("Sprites/Owl"));
        AnimalsDictionary.Add(Animals.Koala, Resources.Load<Sprite>("Sprites/75cbc13aa5f16b2708e15448d702bc32/Cow"));
        AnimalsDictionary.Add(Animals.Cow, Resources.Load<Sprite>("Sprites/75cbc13aa5f16b2708e15448d702bc32/Owl"));
        AnimalsDictionary.Add(Animals.Lion, Resources.Load<Sprite>("Sprites/75cbc13aa5f16b2708e15448d702bc3218"));
        AnimalsDictionary.Add(Animals.Giraffe, Resources.Load<Sprite>("Sprites/75cbc13aa5f16b2708e15448d702bc3219"));
    }
    private void AddColorsInDictionray()
    {
        ColorsDictionary.Add(Colors.Blue, new Color32(100, 100, 255, 255));
        ColorsDictionary.Add(Colors.Green, new Color32(100, 255, 100, 255));
        ColorsDictionary.Add(Colors.Turquoise, new Color32(50, 225, 255, 255));
        ColorsDictionary.Add(Colors.Purple, new Color32(175, 100, 255, 255));
        ColorsDictionary.Add(Colors.Pink, new Color32(255, 150, 255, 255));
        ColorsDictionary.Add(Colors.White, new Color32(225, 225, 225, 255));
    }
}
