using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shapes
{

}
public enum Animals
{

}
public enum Colors
{

}

public class Piece : MonoBehaviour
{
    private Shapes _shape;
    private Animals _animal;
    private Colors _color;

    public Shapes Shape => _shape;
    public Animals Animal => _animal;
    public Colors Color => _color;
}
