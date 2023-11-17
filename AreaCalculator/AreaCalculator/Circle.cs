namespace AreaCalculator;

public class Circle : IAreaCalculable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class
    /// </summary>
    /// <param name="radius"></param>
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius), "radius must be positive");
        }
        
        Radius = radius;
    }

    /// <summary>
    /// Gets radius of the circle
    /// </summary>
    public double Radius { get; }

    /// <inheritdoc cref="CalculateArea"/>
    public double CalculateArea()
        => Math.PI * Math.Pow(Radius, 2);
}