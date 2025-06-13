using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceType
{
    private Shapes _shape;
    private Animals _animal;
    private Colors _color;


    public Shapes Shape => _shape;
    
    public Animals Animal => _animal;
    public Colors Color => _color;

    public void Initialize(Shapes shape, Animals animal, Colors color)
    {
        _shape = shape;
        _animal = animal;
        _color = color;
    }
}
