using Godot;

public partial class BagCoins : Node2D {
    private int coin;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {}

    public void OnBodyEntered(Node2D body) {
        if (body.IsInGroup("player")) {
            GetNode<AudioStreamPlayer>("AudioStreamPlayer").Play(1f);
            
            coin = GetTree().CurrentScene.GetNode<CharacterBody2D>("Player").GetNode<Money>("Money").money.ToInt();
            coin += 20;
            GetTree().CurrentScene.GetNode<CharacterBody2D>("Player").GetNode<Money>("Money").money = coin.ToString();
            QueueFree();
        }
    }
}