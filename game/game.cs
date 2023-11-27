using Godot;

public partial class game : Node2D {
    [Export] public SmallCoin small_coin;
    [Export] private PackedScene small_coin_scn;

    private float test;

    public override void _Ready() {}

    public override void _Process(double delta) {
        small_coin = (SmallCoin)small_coin_scn.Instantiate();
    }
}