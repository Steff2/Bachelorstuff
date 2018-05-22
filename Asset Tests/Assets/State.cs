public abstract class State
{
    protected Character gameState;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(Character gameState)
    {
        this.gameState = gameState;
    }
}
