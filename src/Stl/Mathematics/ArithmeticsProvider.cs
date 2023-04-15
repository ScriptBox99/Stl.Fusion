using Stl.Mathematics.Internal;

namespace Stl.Mathematics;

public abstract class ArithmeticsProvider
{
    public static ArithmeticsProvider Default { get; set; } = new DefaultArithmeticsProvider();

    public abstract Arithmetics<T> Get<T>()
        where T : notnull;
}
