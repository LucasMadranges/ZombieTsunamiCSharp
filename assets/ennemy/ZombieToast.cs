using Godot;

public partial class ZombieToast : RigidBody2D {
    private const float SPEED = 0.2f;

    private Vector2 move = Vector2.Zero;

    private int moveDirX = 1;
    private int moveDirY = 1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        var mobTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();
        animatedSprite2D.Play(mobTypes[0]);

        // Choose a random location on Path2D.
        var mobSpawnLocation = GetTree().CurrentScene.GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
        mobSpawnLocation.ProgressRatio = GD.Randf();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        var target = GetTree().CurrentScene.GetNode<CharacterBody2D>("Player").Position;
        var targetPosition = (target - Position).Normalized();
        MoveAndCollide(targetPosition * SPEED);
    }
}