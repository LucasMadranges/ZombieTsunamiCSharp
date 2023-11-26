using Godot;

public partial class Health : Node2D {
    private Vector2 enemy_position;
    [Export] public float health;

    [Export] public float max_health = 100f;

    [Export] private PackedScene small_coin_scn;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        health = max_health;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {}

    public void Damage(float damage) {
        health -= damage;
        if (health <= 0) {
            var small_coin = GetTree().CurrentScene.GetNode<SmallCoin>("SmallCoin");

            enemy_position = GetTree().CurrentScene.GetNode<ZombieToast>("ZombieToast").Position;
            small_coin.Position = enemy_position;
            GetTree().CurrentScene.AddChild(small_coin);
            GetParent().QueueFree();
        }
    }
}