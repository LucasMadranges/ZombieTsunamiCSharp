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
            /*
            SmallCoin small_coin = (SmallCoin)small_coin_scn.Instantiate();
            enemy_position = GetTree().CurrentScene.GetNode<ZombieToast>("ZombieToast").Position;
            GetTree().CurrentScene.AddChild(small_coin);
            small_coin.Position = enemy_position;
            */
            
            GetParent().QueueFree();
        }
    }
}