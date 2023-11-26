using Godot;

public partial class medkit : Node2D {
    private bool isInRange;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        if (isInRange) QueueFree();
    }

    public void OnBodyEntered(Node2D body) {
        if (IsInGroup("player")) isInRange = true;
    }
}