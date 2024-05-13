using Godot;

public partial class CharacterMovement : CharacterBody2D
{
    private Vector2 _targetPosition;
    [Export] public float Speed = 50f;
    
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("move"))
        {
            var mousePos = GetGlobalMousePosition();
            _targetPosition = mousePos;
        }
    }

    public override void _Process(double delta)
    {
        MoveTowardsTarget(delta);
    }

    private void MoveTowardsTarget(double delta)
    {
        Vector2 direction = (_targetPosition - Position).Normalized();
        Vector2 velocity = direction * Speed;
        Velocity = velocity;
        MoveAndSlide();
    }
}
