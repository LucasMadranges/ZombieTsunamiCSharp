using Godot;
using System;

public partial class game : Node2D
{
    // Don't forget to rebuild the project so the editor knows about the new export variable.

    [Export]
    public PackedScene MobScene { get; set; }

    private int _score; 
}
