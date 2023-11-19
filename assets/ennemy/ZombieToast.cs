using System.Diagnostics;
using Godot;

public partial class ZombieToast : CharacterBody2D {
    private const float SPEED = 0.2f;

    [Export] private float aps = 2f;

    private float attack_speed;
    [Export] private float damage = 10f;
    private Player player;
    private float time_until_attack;
    private bool within_attack_range;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        // var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        // var mobTypes = animatedSprite2D.SpriteFrames.GetAnimationNames();
        // animatedSprite2D.Play(mobTypes[0]);

        attack_speed = 1 / aps;
        time_until_attack = attack_speed;

        // Choose a random location on Path2D.
        var mobSpawnLocation = GetTree().CurrentScene.GetNode<PathFollow2D>("MobPath/MobSpawnLocation");
        mobSpawnLocation.ProgressRatio = GD.Randf();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
        var target = GetTree().CurrentScene.GetNode<CharacterBody2D>("Player");
        var targetPosition = (target.Position - Position).Normalized();
        MoveAndCollide(targetPosition * SPEED);
        LookAt(target.GlobalPosition);

        if (within_attack_range && time_until_attack <= 0) {
            Attack();
            time_until_attack = attack_speed;
        }
        else {
            time_until_attack -= (float)delta;
        }
    }

    public void Attack() {
        Debug.Print("Attack player");
    }

    public void OnAttackBodyEnter(Node2D body) {
        if (body.IsInGroup("player")) within_attack_range = true;
    }

    public void OnAttackBodyExit(Node2D body) {
        if (body.IsInGroup("player")) {
            within_attack_range = false;
            time_until_attack = attack_speed;
        }
    }
}