using Godot;

public partial class EnemySpawner : Node2D {
    [Export] private PackedScene enemy_scn;
    [Export] private float eps = 1f;
    [Export] private Node2D[] spawn_point;

    private float spawn_rate;

    private float time_until_spawn = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        spawn_rate = 1 / eps;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        if (time_until_spawn > spawn_rate) {
            Spawn();
            time_until_spawn = 0;
        }
        else {
            time_until_spawn += (float)delta;
        }
    }

    void Spawn() {
        RandomNumberGenerator rng = new RandomNumberGenerator();
        Vector2 location = spawn_point[rng.Randi() % spawn_point.Length].GlobalPosition;
        ZombieToast zombie = (ZombieToast)enemy_scn.Instantiate();
        zombie.GlobalPosition = location;
        GetTree().Root.AddChild(zombie);
    }
}