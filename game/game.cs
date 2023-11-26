using Godot;

public partial class game : Node2D {
    private float test = 0;
    public override void _Ready() {}

    public override void _Process(double delta) {
        test += (float)delta;
        GD.Print(test);
    }
}