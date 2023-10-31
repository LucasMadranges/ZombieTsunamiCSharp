using Godot;

public partial class game : Node2D {
    private int _score;
    // Don't forget to rebuild the project so the editor knows about the new export variable.

    [Export] public PackedScene MobScene { get; set; }
}