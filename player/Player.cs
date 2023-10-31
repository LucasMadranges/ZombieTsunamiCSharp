using Godot;

public partial class Player : CharacterBody2D {
    public Vector2 ScreenSize; // Size of the game window.

    // Called when the node enters the scene tree for the first time.    [Export]
    public int Speed { get; set; } = 100; // How fast the player will move (pixels/sec).

    public override void _Ready() {
        ScreenSize = GetViewportRect().Size;
    }

    public override void _Process(double delta) {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right")) velocity.X += 1;

        if (Input.IsActionPressed("move_left")) velocity.X -= 1;

        if (Input.IsActionPressed("move_down")) velocity.Y += 1;

        if (Input.IsActionPressed("move_up")) velocity.Y -= 1;

        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        if (velocity.Length() > 0) {
            velocity = velocity.Normalized() * Speed;
            animatedSprite2D.Play();
        }

        {
            animatedSprite2D.Stop();
        }

        Position += velocity * (float)delta;
        Position = new Vector2(
            Mathf.Clamp(Position.X, 0, ScreenSize.X),
            Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
        );

        if (velocity.X > 0) {
            animatedSprite2D.Animation = "right";
            animatedSprite2D.FlipH = velocity.X < 0;
        }
        else if (velocity.X < 0) {
            animatedSprite2D.Animation = "left";
            animatedSprite2D.FlipV = velocity.X > 0;
        }
        else if (velocity.Y > 0) {
            animatedSprite2D.Animation = "down";
            animatedSprite2D.FlipV = velocity.Y < 0;
        }
        else if (velocity.Y < 0) {
            animatedSprite2D.Animation = "up";
            animatedSprite2D.FlipV = velocity.Y > 0;
        }

        if (Input.IsActionJustReleased("move_right")) animatedSprite2D.Animation = "right_stop";
        if (Input.IsActionJustReleased("move_left")) animatedSprite2D.Animation = "left_stop";
        if (Input.IsActionJustReleased("move_up")) animatedSprite2D.Animation = "up_stop";
        if (Input.IsActionJustReleased("move_down")) animatedSprite2D.Animation = "down_stop";

        MoveAndSlide();
    }
}