using Godot;

public partial class zombie_toast : CharacterBody2D {
    public int Speed { get; set; } = 100; // How fast the player will move (pixels/sec).

    public override void _Ready() {
        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animatedSprite2D.Play();
    }

    public override void _Process(double delta) {
        var velocity = Vector2.Zero;

        velocity.X += 1;
    }
}