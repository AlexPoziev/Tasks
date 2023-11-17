using AreaCalculator;

namespace AreaCalculatorTests;

public class Tests
{
    private const double delta = 0.0001;
    
    [Test]
    public void CircleAreaCalculationShouldReturnExpectedValue()
    {
        const double expectedResult = Math.PI * 25;
        
        var circle = new Circle(5);
        
        Assert.That(circle.CalculateArea(), Is.EqualTo(expectedResult).Within(delta));
    }

    [TestCase(3, 4, 5, 6)]
    [TestCase(1, 1, 1, 0.43301)]
    public void TriangleAreaCalculationShouldReturnExpectedValue(double firstSide, double secondSide, double thirdSide, double expectedResult)
    {
        var triangle = new Triangle(firstSide, secondSide, thirdSide);
        
        Assert.That(triangle.CalculateArea(), Is.EqualTo(expectedResult).Within(delta));
    }

    [Test]
    public void ShapesAreasShouldToBeCalculatedCorrect()
    {
        var expectedResult = new List<double> { 30, Math.PI, 6 };
        var actualResult = new List<IAreaCalculable>
        {
            new Triangle(12, 5, 13),
            new Circle(1),
            new Triangle(3, 4, 5)
        }.Select(s => s.CalculateArea()).ToList();

        Assert.That(actualResult, Is.EqualTo(expectedResult).Within(delta));
    }

    [Test]
    public void ShapeInitializationWithLessThanOrEqualToZeroNumbersShouldThrowArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(-1, 2, 3));
        
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 0, 3));
        
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(1, 2, -3));
        
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
    }

    [Test]
    public void TryingToCreateNotExistingTriangleShouldThrowArgumentException()
        => Assert.Throws<ArgumentException>(() => new Triangle(1, 2 , 3));
    
    [Test]
    public void RightAngledTriangleShouldReturnExpectedValue()
    {
        var triangle = new Triangle(3, 4, 5);
        
        Assert.That(triangle.IsRightAngled, Is.True);
    }
}