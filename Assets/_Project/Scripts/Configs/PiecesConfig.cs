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

    [Inject]
    public void Construct()
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
        AnimalsDictionary.Add(Animals.Raccoon, Resources.Load("Sprites/75cbc13aa5f16b2708e15448d702bc32_4.png") as Sprite);
        AnimalsDictionary.Add(Animals.Hare, Resources.Load("Sprites/75cbc13aa5f16b2708e15448d702bc32_7.png") as Sprite);
        AnimalsDictionary.Add(Animals.Panda, Resources.Load("Sprites/75cbc13aa5f16b2708e15448d702bc32_8.png") as Sprite);
        AnimalsDictionary.Add(Animals.Owl, Resources.Load("Sprites/75cbc13aa5f16b2708e15448d702bc32_9.png") as Sprite);
        AnimalsDictionary.Add(Animals.Koala, Resources.Load("Sprites/75cbc13aa5f16b2708e15448d702bc32_12.png") as Sprite);
        AnimalsDictionary.Add(Animals.Cow, Resources.Load("Sprites/75cbc13aa5f16b2708e15448d702bc32_16.png") as Sprite);
        AnimalsDictionary.Add(Animals.Lion, Resources.Load("Sprites/75cbc13aa5f16b2708e15448d702bc32_18.png") as Sprite);
        AnimalsDictionary.Add(Animals.Giraffe, Resources.Load("Sprites/75cbc13aa5f16b2708e15448d702bc32_19.png") as Sprite);
    }
    private void AddColorsInDictionray()
    {
        ColorsDictionary.Add(Colors.Blue, new Color(100,100,255));
        ColorsDictionary.Add(Colors.Green, new Color(100, 200, 100));
        ColorsDictionary.Add(Colors.Turquoise, new Color(50, 225, 200));
        ColorsDictionary.Add(Colors.Purple, new Color(175, 100, 255));
        ColorsDictionary.Add(Colors.Pink, new Color(255, 150, 255));
        ColorsDictionary.Add(Colors.White, new Color(225, 225, 225));
    }
}
