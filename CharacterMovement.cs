using Godot;

namespace uncannydodge;

public partial class CharacterMovement : CharacterBody2D
{
    private Vector2 _targetPosition;
    private bool _isSelected;
    [Export] public float Speed = 50f;

    public void Select()
    {
        _isSelected = true;
    }

    public void Deselect()
    {
        _isSelected = false;
    }
    
    public override void _Input(InputEvent @event)
    {
        if(!_isSelected) return;
        if (!@event.IsActionPressed("move")) return;
        _targetPosition = GetGlobalMousePosition();
    }

    public override void _Process(double delta)
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        var direction = (_targetPosition - Position).Normalized();
        Velocity = direction * Speed;;
        MoveAndSlide();
    }
}