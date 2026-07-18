namespace NeuralNetwork;

public class Perceptron
{
    private double[] weights;
    private double bias;
    private double learningRate;

    public Perceptron(int inputSize, double learningRate = 0.01)
    {
        this.learningRate = learningRate;
        weights = new double[inputSize];
        bias = 0;
        InitializeWeights();
    }

    private void InitializeWeights()
    {
        var rand = new Random();
        for (int i = 0; i < weights.Length; i++)
            weights[i] = rand.NextDouble() - 0.5; 
    }
    
    public double Predict(double[] inputs)
    {
        double sum = bias;
        for (int i = 0; i < inputs.Length; i++)
            sum += weights[i] * inputs[i];
        
        return sum; 
    }
    
    public void Train(double[][] trainingData, double[] labels, int epochs)
    {
        for (int epoch = 1; epoch <= epochs; epoch++)
        {
            double totalError = 0;

            for (int i = 0; i < trainingData.Length; i++)
            {
                double prediction = Predict(trainingData[i]);
                double error = labels[i] - prediction;
                
                totalError += Math.Abs(error);
                
                for (int j = 0; j < weights.Length; j++)
                    weights[j] += learningRate * error * trainingData[i][j];
                bias += learningRate * error;
            }
            
            if (epoch % 10 == 0 || epoch == 1)
            {
                double averageError = totalError / trainingData.Length;
                Console.WriteLine($"Эпоха {epoch}: средняя ошибка = {averageError:F4}");
            }
        }
    }
}