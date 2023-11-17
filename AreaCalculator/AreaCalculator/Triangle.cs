namespace AreaCalculator;

public class Triangle : IAreaCalculable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Triangle"/> class
    /// </summary>
    public Triangle(double firstSide, double secondSide, double thirdSide)
    {
        void ThrowIfLessOrEqualZero(double side, string name)
        {
            if (side <= 0)
            {
                throw new ArgumentOutOfRangeException(name, "side cannot to be less or equal to zero");
            }
        }

        FirstSide = firstSide;
        ThrowIfLessOrEqualZero(firstSide, nameof(firstSide));
        SecondSide = secondSide;
        ThrowIfLessOrEqualZero(secondSide, nameof(secondSide));
        ThirdSide = thirdSide;
        ThrowIfLessOrEqualZero(thirdSide, nameof(thirdSide));

        sortedSides = new[] { firstSide, secondSide, thirdSide };

        if (sortedSides[0] + sortedSides[1] <= sortedSides[2])
        {
            throw new ArgumentException("Triangle with these sides doesn't exist. Reason: sum of two sides less than the third");
        }

        Array.Sort(sortedSides);
    }

    private const double delta = 0.0001;

    /// <summary>
    /// Gets first size of the triangle
    /// </summary>
    public double FirstSide { get; }

    /// <summary>
    /// Gets second size of the triangle
    /// </summary>
    public double SecondSide { get; }

    /// <summary>
    /// Gets third size of the triangle
    /// </summary>
    public double ThirdSide { get; }

    private double[] sortedSides;

    /// <inheritdoc cref="CalculateArea"/>
    public double CalculateArea()
    {
        if (IsRightAngled)
        {
            return 0.5 * sortedSides[0] * sortedSides[1];
        }

        var halfPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;

        return Math.Sqrt(halfPerimeter * (halfPerimeter - sortedSides[0]) * (halfPerimeter - sortedSides[1]) * (halfPerimeter - sortedSides[2]));
    }

    /// <summary>
    /// Gets is triangle right angled
    /// </summary>
    /// <returns>true -- right angled, false -- does not</returns>
    public bool IsRightAngled
    {
        get => Math.Abs(Math.Pow(sortedSides[0], 2) + Math.Pow(sortedSides[1], 2) - Math.Pow(sortedSides[2], 2)) < delta;
    }
}