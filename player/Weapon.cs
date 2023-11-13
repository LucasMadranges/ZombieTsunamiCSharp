using Godot;

public partial class Weapon : Node2D {
    [Export] private float bps = 5f;
    [Export] private float bullet_damage = 30f;
    [Export] private PackedScene bullet_scn;
    [Export] private float bullet_speed = 100f;

    private float fire_rate;

    private float time_until_fire;

    public override void _Ready() {
        fire_rate = 1 / bps;
    }

    public override void _PhysicsProcess(double delta) {
        if (Input.IsActionPressed("fire") && time_until_fire > fire_rate) {
            var bullet = bullet_scn.Instantiate<RigidBody2D>();

            bullet.Rotation = GlobalRotation;
            bullet.GlobalPosition = GlobalPosition;
            bullet.LinearVelocity = bullet.Transform.X * bullet_speed;

            GetTree().Root.AddChild(bullet);

            time_until_fire = 0f;
        }
        else {
            time_until_fire += (float)delta;
        }
    }
}