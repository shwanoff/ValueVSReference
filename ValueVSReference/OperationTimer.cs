using System;
using System.Diagnostics;

namespace ValueVSReference
{
    /// <summary>
    /// Класс для оценки времени выполнения операций 
    /// </summary>
    internal class OperationTimer : IDisposable
    {
        private Stopwatch _stopwatch;
        private string _text;
        private int _collectionCount;

        public OperationTimer(string text)
        {
            PrepareForOperation();

            _text = text;
            _collectionCount = GC.CollectionCount(0);

            // Эта команда должна быть последней в этом методе     
            // для максимально точной оценки быстродействия    
            _stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine("{0} (GCs={1,3}) {2}", (_stopwatch.Elapsed), GC.CollectionCount(0) - _collectionCount, _text);

        }

        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

    }
}