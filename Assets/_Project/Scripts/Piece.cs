using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Piece : MonoBehaviour
{
    private Shapes _shape;
    private Animals _animal;
    private Colors _color;

    public Shapes Shape
    {
        get { return _shape; }
        set{ _shape = value; }
    }
    public Animals Animal
    {
        get { return _animal; }
        set { _animal = value; }
    }
    public Colors Color
    {
        get { return _color; }
        set { _color = value; }
    }
}
