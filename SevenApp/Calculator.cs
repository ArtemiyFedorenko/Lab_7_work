class Calculator<T>
{
    public delegate T ArithmeticOperation(T x, T y);

    public ArithmeticOperation Add { get; set; }
    public ArithmeticOperation Subtract { get; set; }
    public ArithmeticOperation Multiply { get; set; }
    public ArithmeticOperation Divide { get; set; }

    public Calculator()
    {
        Add = (x, y) => (dynamic)x + y;
        Subtract = (x, y) => (dynamic)x - y;
        Multiply = (x, y) => (dynamic)x * y;
        Divide = (x, y) => (dynamic)x / y;
    }

    public T PerformOperation(T x, T y, ArithmeticOperation operation)
    {
        return operation(x, y);
    }
}