Imports MLP
Imports MLP.Data
Imports MLP.Network
Imports MLP.Randoms
Imports MLP.Activation
Imports MLP.Utilities

Module Main

    Sub Main()

        Scenario1()

    End Sub

    Public Sub Scenario1()

        Dim standard As New Standard(New Range(-1, 1), DateTime.Now.Millisecond)

        Dim Network As New MultilayerPerceptron(
            num_input:=2, num_hidden:={5}, num_output:=1, learning_rate:=0.5,
            momentum:=0.8, randomizer:=standard, activation:=New BipolarSigmoid(0.5))

        Dim Training As New List(Of Training)
        Training.Add(New Training({0, 1}, {1}))
        Training.Add(New Training({0, 0}, {0}))
        Training.Add(New Training({1, 0}, {1}))
        Training.Add(New Training({1, 1}, {0}))

        'Dim result = False
        'While Not result
        '    Network.Train(Training, 5, 0.1)
        '    Console.WriteLine(String.Format("Total error on correctly predicting training set: {0}", Network.TotalError))
        '    Console.ReadLine()
        'End While

        Dim nbIterations% = 3000
        For iteration As Integer = 0 To nbIterations - 1

            Network.TrainOneIteration(Training)

            If (iteration < 10 OrElse
                ((iteration + 1) Mod 100 = 0 AndAlso iteration < 1000) OrElse
                ((iteration + 1) Mod 1000 = 0 AndAlso iteration < 10000) OrElse
                (iteration + 1) Mod 10000 = 0) Then
                Dim msg$ = vbLf & "Iteration n°" & iteration + 1 & "/" & nbIterations & vbLf &
                    "Output: " & Network.PrintOutput() & vbLf &
                    "Average error: " & Network.TotalError.ToString("0.000000")
                Console.WriteLine(msg)
            End If

        Next
        Console.WriteLine("Press a key to quit.")
        Console.ReadLine()

    End Sub

End Module
