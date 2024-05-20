using Godot;

namespace uncannydodge;

public partial class SkeletonMage : Node2D
{
    private RandomNumberGenerator _randomNumberGenerator;
    [Export] public float Range;
    [Export] public AttackZone AttackZone;
    [Export] public Party Party;

    public override void _Ready()
    {
        _randomNumberGenerator = new RandomNumberGenerator();
    }

    public void Attack()
    {
        var target = Party.PartyMembers[_randomNumberGenerator.RandiRange(0, Party.PartyMembers.Length - 1)];
        var x = _randomNumberGenerator.Randf();
        var y = _randomNumberGenerator.Randf();
        if (_randomNumberGenerator.Randf() > 0.5) x = -x;
        if (_randomNumberGenerator.Randf() > 0.5) y = -y;
        var direction = new Vector2(x, y).Normalized();
        var range = _randomNumberGenerator.RandfRange(0, Range);
        AttackZone.GlobalPosition = target.GlobalPosition + direction * range;
    }
}