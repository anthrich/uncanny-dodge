using Godot;

namespace uncannydodge;

public partial class CharacterMovement : CharacterBody2D
{
    private Vector2 _targetPosition;
    [Export] public  bool IsSelected;
    [Export] public bool IsHoveredByMouse;
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
        MouseEntered += () => IsHoveredByMouse = true;
        MouseExited += () => IsHoveredByMouse = false;
    }

    [Signal]
    public delegate void SelectedEventHandler(CharacterMovement characterMovement);
    
    public void Select()
    {
        IsSelected = true;
        SelectedSprite2D.Visible = true;
        EmitSignal(SignalName.Selected, Variant.From(this));
    }

    public void Deselect()
    {
        IsSelected = false;
        SelectedSprite2D.Visible = false;
    }
    
    public override void _Input(InputEvent @event)
    {
        if (IsHoveredByMouse && @event is InputEventMouseButton mouseButtonEvent)
        {
            mouseButtonEvent.IsAction("select");
            Select();
            return;
        }

        if (IsSelected && @event.IsActionPressed("move"))
        {
            _targetPosition = GetGlobalMousePosition();
        }
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