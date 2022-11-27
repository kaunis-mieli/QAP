using QAP.Core.Models.Problem;
using QAP.DataContext;
using QAP.UnitOfWork.Factories;
using QAP.UnitOfWork.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QAP.UnitOfWork.UnitOfWork.Algorithm.LocalSearch;

public class LocalSearch001Config : IAlgorithmConfig
{
    public int Iterations { get; set; }
    public int Trials { get; set; }
}

public class LocalSearch001 : Algorithm<LocalSearch001Config>
{
    public LocalSearch001(SessionAlgorithmVersion sessionAlgorithmVersion, UoWFactory uoWFactory) : base(uoWFactory) 
    {
        Configuration = sessionAlgorithmVersion.Configuration is not null ?
            JsonSerializer.Deserialize<LocalSearch001Config>(sessionAlgorithmVersion.Configuration) :
            JsonSerializer.Deserialize<LocalSearch001Config>(sessionAlgorithmVersion.AlgorithmVersion.DefaultConfiguration);
    }

    public override void Solve()
    {
        var problemModel = ConversionHelpers.GetProblemModel(sessionAlgorithmVersion.Session.Problem);

        Console.WriteLine("--------Problem: " + problemModel.Alias);

        var N = problemModel.Size;
        var A = problemModel.MatrixA;
        var B = problemModel.MatrixB;

        var permutation = uoWFactory.PermutationUnitOfWork.CreateRandomPermutation(problemModel);
        var P = permutation.Value;
        var F = permutation.Cost;

        var Delta = new long[N, N];
        var isLocalOptimum = false;
        long minDelta, sum;
        int tmp;

        InitialDeltaCalculation(N, A, B, P, Delta);

        Console.WriteLine($"Cost: {F}, " +
            $"Initial permutation: {string.Join(",", P)}");

        for (int iterations = Configuration.Iterations; !isLocalOptimum && iterations > 0; --iterations)
        {
            isLocalOptimum = true;
            minDelta = 0;

            var u = 0;
            var v = 0;

            for (int q = 0; q < N; q++)
            {
                for (int r = q + 1; r < N; r++)
                {
                    if (Delta[q, r] < minDelta)
                    {
                        minDelta = Delta[q, r]; // min_delta - minimum difference in 
                                                // the objective function values     
                        u = q; v = r;
                    }
                }
            }

            if (minDelta < 0)
            {
                // move to a new solution
                F += minDelta; // new objective function value
                tmp = P[u]; P[u] = P[v]; P[v] = tmp; // new permutation
                                                     // recalculation of the values of Delta 
                                                     // after interchanging the u-th and v-th elements in P
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if ((i != u) && (i != v) && (j != u) && (j != v))
                        {
                            Delta[i, j] += (A[i, u] - A[i, v] + A[j, v] - A[j, u]) *
                                            (B[P[i], P[v]] - B[P[i], P[u]] +
                                            B[P[j], P[u]] - B[P[j], P[v]]) +
                                            (A[u, i] - A[v, i] + A[v, j] - A[u, j]) *
                                            (B[P[v], P[i]] - B[P[u], P[i]] +
                                            B[P[u], P[j]] - B[P[v], P[j]]);
                        }
                        else
                        {
                            sum = 0;

                            for (int k = 0; k < N; k++)
                            {
                                if ((k != i) && (k != j))
                                {
                                    sum += (A[i, k] - A[j, k]) * (B[P[j], P[k]] - B[P[i], P[k]]) +
                                           (A[k, i] - A[k, j]) * (B[P[k], P[j]] - B[P[k], P[j]]);
                                }

                                Delta[i, j] = (A[i, i] - A[j, j]) * (B[P[j], P[j]] - B[P[i], P[j]]) +
                                        (A[i, j] - A[j, i]) * (B[P[j], P[i]] - B[P[i], P[i]]) + sum;
                            }
                        }
                    }
                }

                isLocalOptimum = false; // not yet a locally optimal solution
            }

            Console.WriteLine($"#{Configuration.Iterations - iterations} CostByDeltaCalculation: {F}, " +
                $"CostByFormula: {PermutationUnitOfWork.CalculateCost(problemModel, P)}, " +
                $"Permutation: {string.Join(",", P)}");

            //F = PerformOneIteration(problemInstanceModel, N, A, B, P, F, Delta, out isLocalOptimum, out delta, out minDelta, out sum, out tmp, iterations);
        }

        Console.WriteLine("========FINISH==========");
    }

    private static void InitialDeltaCalculation(int N, MatrixWrapper A, MatrixWrapper B, int[] P, long[,] Delta)
    {
        long sum, delta;

        for (int u = 0; u < N; u++)
        {
            for (int v = 0; v < N; v++)
            {
                sum = 0;

                for (int k = 0; k < N; k++)
                {
                    if (k != u && k != v)
                    {
                        sum += (A[u, k] - A[v, k]) * (B[P[v], P[k]] - B[P[u], P[k]]) +
                                   (A[k, u] - A[k, v]) * (B[P[k], P[v]] - B[P[k], P[u]]);

                        delta = (A[u, u] - A[v, v]) * (B[P[v], P[v]] - B[P[u], P[u]]) +
                            (A[u, v] - A[v, u]) * (B[P[v], P[u]] - B[P[u], P[v]]) + sum;

                        Delta[u, v] = delta;
                    }
                }
            }
        }
    }
}
