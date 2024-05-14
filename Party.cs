using System.Linq;
using Godot;
using uncannydodge;

public partial class Party : Node2D
{
    private CharacterMovement[] _partyMembers;

    public override void _Ready()
    {
        _partyMembers = GetChildren().OfType<CharacterMovement>().ToArray();
    }

    public override void _Input(InputEvent @event)
    {
        for (var partyMember = 1; partyMember <= _partyMembers.Length; partyMember++)
        {
            if (!@event.IsActionPressed("select" + partyMember)) continue;
            
            foreach (var member in _partyMembers)
            {
                member.Deselect();
            }
            
            _partyMembers[partyMember - 1].Select();
            break;
        }
    }
}
