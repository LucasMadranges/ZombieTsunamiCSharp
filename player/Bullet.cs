using Godot;

public partial class Bullet : RigidBody2D {
    // Called when the node enters the scene tree for the first time.
    [Export] public float damage = 10;

    public override void _Ready() {
        var timer = GetNode<Timer>("Timer");
        timer.Timeout += () => QueueFree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {}

    public void OnBodyEntered(Node2D body) {
        if (body.IsInGroup("enemy")) body.GetNode<Health>("Health").Damage(damage);

        QueueFree();
    }
}