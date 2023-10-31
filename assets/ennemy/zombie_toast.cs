using Godot;

public partial class zombie_toast : RigidBody2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        var walkZombie = animatedSprite2D.SpriteFrames.GetAnimationNames();
        animatedSprite2D.Play(walkZombie[2]);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}