using Godot;

public partial class TextEdit : Godot.TextEdit {
    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        Text = GetTree().CurrentScene.GetNode<CharacterBody2D>("Player").GetNode<Money>("Money").money;
    }
}