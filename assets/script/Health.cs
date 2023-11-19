using Godot;

public partial class Health : Node2D {
    private float health;

    [Export] public float max_health = 100f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        health = max_health;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {}

    public void Damage(float damage) {
        health -= damage;

        if (health <= 0) GetParent().QueueFree();
    }
}