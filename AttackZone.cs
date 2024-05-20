using Godot;

namespace uncannydodge;

public partial class AttackZone : Node2D
{
    [Export] public float ExpansionTimeInSeconds = 2;
    private bool _isExpanding = false;

    public override void _Ready()
    {
        Visible = false;
    }

    public void StartAttack()
    {
        Scale = Vector2.Zero;
        _isExpanding = true;
        Visible = true;
    }

    public override void _Process(double delta)
    {
        if(!_isExpanding) return;
        var f = (float)delta;
        Scale = new Vector2(Scale.X + f / ExpansionTimeInSeconds, Scale.Y + f / ExpansionTimeInSeconds);
        if (Scale.X > 1f)
        {
            Scale = Scale.Clamp(Vector2.Zero, Vector2.One);
            _isExpanding = false;
            Visible = false;
        }
    }
}