using Godot;

namespace uncannydodge;

public partial class CharacterMovement : CharacterBody2D
{
    private Vector2 _targetPosition;
    private bool _isSelected;
    [Export] public float Speed = 50f;
    [Export] public Sprite2D SelectedSprite2D;
    [Export] public int MaxHealth = 15;
    [Export] public int CurrentHealth;
    [Export] public TextureProgressBar HealthBar;

    public override void _Ready()
    {
        _targetPosition = Position;
        CurrentHealth = MaxHealth;
        HealthBar.MaxValue = MaxHealth;
        HealthBar.Value = CurrentHealth;
    }

    public void Select()
    {
        _isSelected = true;
        SelectedSprite2D.Visible = true;
    }

    public void Deselect()
    {
        _isSelected = false;
        SelectedSprite2D.Visible = false;
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