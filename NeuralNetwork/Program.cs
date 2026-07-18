using NeuralNetwork;

double[][] trainingData = new double[100][];
double[] labels = new double[100];
int index = 0;

for (int i = 0; i < 10; i++)
{
    for (int j = 0; j < 10; j++)
    {
        trainingData[index] = new double[] { i, j };
        labels[index] = i + j;
        index++;
    }
}

Console.WriteLine("Обучение нейросети...");
Perceptron perceptron = new Perceptron(inputSize: 2, learningRate: 0.01);
perceptron.Train(trainingData, labels, epochs: 100);
Console.WriteLine("Обучение завершено!\n");

while (true)
{
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("Введите пример сложения чисел (формат: 5+3) >> ");
    string input = Console.ReadLine();
    
    string[] parts = input?.Split('+');

    if (parts?.Length == 2 
        && double.TryParse(parts[0].Trim(), out double num1) 
        && double.TryParse(parts[1].Trim(), out double num2))
    {
        double[] userInputs = new double[] { num1, num2 };
        double prediction = perceptron.Predict(userInputs);

        Console.WriteLine($"\nПравильный ответ: {num1 + num2}");
        Console.WriteLine($"Ответ нейросети:  {prediction:F2} (округленно: {Math.Round(prediction)})");
    }
    else
    {
        Console.WriteLine("Неправилньный формат ввода.");
    }
}
