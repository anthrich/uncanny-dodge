using System.Linq;
using Godot;
using uncannydodge;

public partial class Party : Node2D
{
    public CharacterMovement[] PartyMembers;

    public override void _Ready()
    {
        PartyMembers = GetChildren().OfType<CharacterMovement>().ToArray();
    }

    public override void _Input(InputEvent @event)
    {
        for (var partyMember = 1; partyMember <= PartyMembers.Length; partyMember++)
        {
            if (!@event.IsActionPressed("select" + partyMember)) continue;
            
            foreach (var member in PartyMembers)
            {
                member.Deselect();
            }
            
            PartyMembers[partyMember - 1].Select();
            break;
        }
    }
}
