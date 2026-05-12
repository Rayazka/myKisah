using myKisah.Automata;
using myKisah.Models;

namespace myKisah.Tests.JournalTests;

// Unit test untuk JournalStateMachine — semua transisi state valid + invalid + terminal.
public class JournalStateMachineTests
{
    private readonly JournalStateMachine _machine;

    public JournalStateMachineTests()
    {
        _machine = new JournalStateMachine();
    }

    // TRANSISI VALID
    [Fact]
    public void Draft_Submit_ReturnsSubmitted()
    {
        var result = _machine.Transition(JournalState.Draft, JournalTrigger.Submit);
        Assert.Equal(JournalState.Submitted, result);
    }

    [Fact]
    public void Submitted_Save_ReturnsSaved()
    {
        var result = _machine.Transition(JournalState.Submitted, JournalTrigger.Save);
        Assert.Equal(JournalState.Saved, result);
    }

    [Fact]
    public void Submitted_Reject_ReturnsRejected()
    {
        var result = _machine.Transition(JournalState.Submitted, JournalTrigger.Reject);
        Assert.Equal(JournalState.Rejected, result);
    }

    [Fact]
    public void Rejected_Reset_ReturnsDraft()
    {
        var result = _machine.Transition(JournalState.Rejected, JournalTrigger.Reset);
        Assert.Equal(JournalState.Draft, result);
    }

    // TRANSISI INVALID
    [Fact]
    public void Saved_Submit_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
            _machine.Transition(JournalState.Saved, JournalTrigger.Submit));

        Assert.Contains("Saved", ex.Message);
        Assert.Contains("Submit", ex.Message);
    }

    [Fact]
    public void Saved_AnyTrigger_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _machine.Transition(JournalState.Saved, JournalTrigger.Save));
        Assert.Throws<InvalidOperationException>(() =>
            _machine.Transition(JournalState.Saved, JournalTrigger.Reject));
        Assert.Throws<InvalidOperationException>(() =>
            _machine.Transition(JournalState.Saved, JournalTrigger.Reset));
    }

    [Fact]
    public void Draft_Save_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _machine.Transition(JournalState.Draft, JournalTrigger.Save));
    }

    [Fact]
    public void Draft_Reject_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _machine.Transition(JournalState.Draft, JournalTrigger.Reject));
    }

    [Fact]
    public void Rejected_Submit_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _machine.Transition(JournalState.Rejected, JournalTrigger.Submit));
    }
    
    // TERMINAL CHECK
    [Fact]
    public void IsTerminal_Saved_ReturnsTrue()
    {
        Assert.True(_machine.IsTerminal(JournalState.Saved));
    }

    [Fact]
    public void IsTerminal_Draft_ReturnsFalse()
    {
        Assert.False(_machine.IsTerminal(JournalState.Draft));
    }

    [Fact]
    public void IsTerminal_Submitted_ReturnsFalse()
    {
        Assert.False(_machine.IsTerminal(JournalState.Submitted));
    }

    [Fact]
    public void IsTerminal_Rejected_ReturnsFalse()
    {
        Assert.False(_machine.IsTerminal(JournalState.Rejected));
    }
}
