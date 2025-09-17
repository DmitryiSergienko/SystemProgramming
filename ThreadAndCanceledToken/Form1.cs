using System;
using System.Threading;
using System.Windows.Forms;

/*
    Задание 1. Создайте оконное приложение, генерирующее квадраты (кубы) чисел в диапазоне, указанном пользователем. 
    Задание 2. Добавьте к первому заданию поток, генерирующий факториалы чисел.
    Задание 3. Добавьте ко второму заданию кнопки для остановки и возобновления каждого из потоков.
    Задание 4. Добавьте к третьему заданию возможность полного рестарта потоков с новыми границами.
*/

namespace ThreadAndCanceledToken
{
    public partial class Form1 : Form
    {
        private Thread _thread;
        private CancellationTokenSource _tokenSource;
        private bool _isSquareCubeThreadRunning = false;
        private bool _isFactorialThreadRunning = false;
        private bool _isSquareCubeRestart = true;
        private bool _isFactorialRestart = true;
        private SquareCubeClass _squareCube;
        private FactorialClass _factorial;

        public Form1()
        {
            InitializeComponent();
            UpdateResultStartButton1();
            UpdateResultStartButton2();
            UpdateControlButtons1();
            UpdateControlButtons2();
        }
        private void UpdateControlButtons1()
        {
            PauseButton1.Enabled = _isSquareCubeThreadRunning;
            StopButton1.Enabled = _isSquareCubeThreadRunning;
            RestartButton1.Enabled = _isSquareCubeThreadRunning && _squareCube != null;            
        }
        private void UpdateControlButtons2()
        {
            PauseButton2.Enabled = _isFactorialThreadRunning;
            StopButton2.Enabled = _isFactorialThreadRunning;
            RestartButton2.Enabled = _isFactorialThreadRunning && _factorial != null;
        }
        private void StartButton1_Click(object sender, EventArgs e)
        {
            if(_squareCube == null)
            {
                _squareCube = new SquareCubeClass(
                    SquareCubeRangeFrom.Text,
                    SquareCubeRangeTo.Text,
                    SquareRadioButton.Checked,
                    CubeRadioButton.Checked
                );
            }
            
            _tokenSource = new CancellationTokenSource();
            _thread = new Thread(() => SquareCube(_squareCube, _tokenSource.Token))
            {
                IsBackground = true
            };
            
            _isSquareCubeThreadRunning = true;
            StartButton1.Enabled = false;
            PauseButton1.Enabled = true;
            StopButton1.Enabled = true;
            RestartButton1.Enabled = true;

            StartButton2.Enabled = false;
            RestartButton2.Enabled = false;
            _thread.Start();
        }
        private void StartButton2_Click(object sender, EventArgs e)
        {
            if(_factorial == null)
            {
                _factorial = new FactorialClass(
                    FactorialRangeFrom.Text,
                    FactorialRangeTo.Text
                );
            }

            _tokenSource = new CancellationTokenSource();
            _thread = new Thread(() => Factorial(_factorial, _tokenSource.Token))
            {
                IsBackground = true
            };

            _isFactorialThreadRunning = true;
            StartButton2.Enabled = false;
            PauseButton2.Enabled = true;
            StopButton2.Enabled = true;
            RestartButton2.Enabled = true;

            StartButton1.Enabled = false;
            RestartButton1.Enabled = false;
            _thread.Start();
        }
        private void PauseButton1_Click(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
            _tokenSource = null;
            _thread = null;

            _isSquareCubeRestart = false;
            StartButton1.Enabled = true;
            StopButton1.Enabled = false;
            PauseButton1.Enabled = false;

            if (_factorial != null)
            {
                StartButton2.Enabled = true;
                RestartButton2.Enabled = true;
            }
        }
        private void PauseButton2_Click(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
            _tokenSource = null;
            _thread = null;
            
            _isFactorialRestart = false;
            StartButton2.Enabled = true;
            PauseButton2.Enabled = false;
            StopButton2.Enabled = false;

            if ( _squareCube != null)
            {
                StartButton1.Enabled = true;
                RestartButton1.Enabled = true;
            }
        }
        private void StopButton1_Click(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
            _tokenSource = null;
            _thread = null;
            _squareCube = null;
            SquareCubeWindow.Clear();
            _isSquareCubeThreadRunning = false;

            StartButton1.Enabled = false;
            PauseButton1.Enabled = false;
            StopButton1.Enabled = false;
            RestartButton1.Enabled = false;

            if (_factorial != null)
            {
                StartButton2.Enabled = true;
                RestartButton2.Enabled = true;
            }
        }
        private void StopButton2_Click(object sender, EventArgs e)
        {
            _tokenSource.Cancel();
            _tokenSource = null;
            _thread = null;
            _factorial = null;
            FactorialWindow.Clear();
            _isFactorialThreadRunning = false;

            StartButton2.Enabled = false;
            PauseButton2.Enabled = false;
            StopButton2.Enabled = false;
            RestartButton2.Enabled = false;

            if (_squareCube != null)
            {
                StartButton1.Enabled = true;
                RestartButton1.Enabled = true;
            }
        }
        private void RestartButton1_Click(object sender, EventArgs e)
        {
            if(_tokenSource != null)
            {
                _tokenSource.Cancel();
                _tokenSource = null;
                _thread = null;
            }
            SquareCubeWindow.Clear();
            _squareCube.Count = 0;

            _tokenSource = new CancellationTokenSource();
            _thread = new Thread(() => SquareCube(_squareCube, _tokenSource.Token))
            {
                IsBackground = true
            };

            _isSquareCubeRestart = false;
            _isSquareCubeThreadRunning = true;
            UpdateControlButtons1();

            StartButton2.Enabled = false;
            RestartButton2.Enabled = false;
            _thread.Start();
        }
        private void RestartButton2_Click(object sender, EventArgs e)
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
                _tokenSource = null;
                _thread = null;
            }
            FactorialWindow.Clear();
            _factorial.Count = 0;

            _tokenSource = new CancellationTokenSource();
            _thread = new Thread(() => Factorial(_factorial, _tokenSource.Token))
            {
                IsBackground = true
            };

            _isFactorialRestart = false;
            _isFactorialThreadRunning = true;
            UpdateControlButtons2();

            StartButton1.Enabled = false;
            RestartButton1.Enabled = false;
            _thread.Start();
        }

        private void SquareCube(SquareCubeClass squareCube, CancellationToken tokenSource)
        {
            var token = tokenSource;

            int NumFrom = 0, NumTo = 0, Count = 0;
            bool SquareChoise = false, CubeChoise = false;

            this.Invoke((Action)(() =>
            {
                Count = squareCube.Count;
                NumFrom = squareCube.FromText;
                NumTo = squareCube.ToText;
                SquareChoise = squareCube.IsSquare;
                CubeChoise = squareCube.IsCube;
                ClearInputs();

                if (NumTo <= NumFrom)
                {
                    MessageBox.Show("Неверно задан диапазон!");
                    _isSquareCubeThreadRunning = false;
                    UpdateControlButtons1();
                    return;
                }
            }));

            NumFrom += Count;
            if (NumTo <= NumFrom) return;

            string choice = "";
            if (SquareChoise) choice = "квадрата";
            else if (CubeChoise) choice = "куба";
                this.Invoke((Action)(() =>
                {
                    if (Count == 0)
                    {
                        SquareCubeWindow.Text += $"Диапазон {choice} чисел от {NumFrom} до {NumTo}:\n";
                    }
                }));
            while (!token.IsCancellationRequested && NumFrom <= NumTo) 
            {
                string textToAdd = "";

                if (SquareChoise)
                    textToAdd = Math.Pow(NumFrom, 2).ToString() + " ";
                else if (CubeChoise)
                    textToAdd = Math.Pow(NumFrom, 3).ToString() + " ";

                this.Invoke((Action)(() =>
                {
                    SquareCubeWindow.Text += textToAdd;
                }));

                if (NumFrom == NumTo)
                {
                    this.Invoke((Action)(() =>
                    {
                        SquareCubeWindow.Text += "\nКонец!\n";
                    }));
                    break;
                }

                Count++;
                squareCube.Count = Count;
                NumFrom++;
                Thread.Sleep(1000);
            }
            this.Invoke((Action)(() =>
            {
                if (_isSquareCubeRestart)
                {
                    _isSquareCubeThreadRunning = false;
                    UpdateControlButtons1();
                }
                _isSquareCubeRestart = true;
            }));
        }
        private void Factorial(FactorialClass factorial, CancellationToken tokenSource)
        {
            var token = tokenSource;

            int NumFrom = 0, NumTo = 0, Count = 0;

            this.Invoke((Action)(() =>
            {
                Count = factorial.Count;
                NumFrom = factorial.FromText;
                NumTo = factorial.ToText;
                ClearInputs();

                if (NumTo <= NumFrom)
                {
                    MessageBox.Show("Неверно задан диапазон!");
                    _isFactorialThreadRunning = false;
                    UpdateControlButtons2();
                    return;
                }
            }));
            NumFrom += Count;
            if (NumTo <= NumFrom) return;

            this.Invoke((Action)(() =>
            {
                if (Count == 0) 
                {
                    FactorialWindow.Text += $"Диапазон от {NumFrom} до {NumTo}:\n";
                }                
            }));
            while (!token.IsCancellationRequested && NumFrom <= NumTo)
            {
                string textToAdd = "";

                long result = 1;
                for (int i = 2; i <= NumFrom; i++)
                {
                    result *= i;
                }
                textToAdd = result.ToString() + " ";

                this.Invoke((Action)(() =>
                {
                    FactorialWindow.Text += textToAdd;
                }));

                if (NumFrom == NumTo)
                {
                    this.Invoke((Action)(() =>
                    {
                        FactorialWindow.Text += "\nКонец!\n";
                    }));
                    break;
                }

                Count++;
                factorial.Count = Count;
                NumFrom++;
                Thread.Sleep(1000);
            }
            this.Invoke((Action)(() =>
            {
                if (_isFactorialRestart)
                {
                    _isFactorialThreadRunning = false;
                    UpdateControlButtons2();
                }
                _isFactorialRestart = true;
            }));
        }

        private void ClearInputs()
        {
            SquareCubeRangeFrom.Clear();
            SquareCubeRangeTo.Clear();
            FactorialRangeFrom.Clear();
            FactorialRangeTo.Clear();
            SquareRadioButton.Checked = false;
            CubeRadioButton.Checked = false;
        }
        private void UpdateResultStartButton1()
        {
            StartButton1.Enabled = SquareCubeRangeFrom.Text.Length > 0 && SquareCubeRangeTo.Text.Length > 0 &&
                (SquareRadioButton.Checked || CubeRadioButton.Checked);
        }
        private void UpdateResultStartButton2()
        {
            StartButton2.Enabled = FactorialRangeFrom.Text.Length > 0 && FactorialRangeTo.Text.Length > 0;
        }

        private void SquareCubeRangeFrom_TextChanged(object sender, EventArgs e)
        {
            UpdateResultStartButton1();
        }
        private void SquareCubeRangeTo_TextChanged(object sender, EventArgs e)
        {
            UpdateResultStartButton1();
        }
        private void SquareRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateResultStartButton1();
        }
        private void CubeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateResultStartButton1();
        }
        private void SquareCubeRangeFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и клавишу Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // отменяем ввод этого символа
            }
        }
        private void SquareCubeRangeTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и клавишу Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // отменяем ввод этого символа
            }
        }
        private void FactorialRangeFrom_TextChanged(object sender, EventArgs e)
        {
            UpdateResultStartButton2();
        }
        private void FactorialRangeTo_TextChanged(object sender, EventArgs e)
        {
            UpdateResultStartButton2();
        }
        private void FactorialRangeFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и клавишу Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // отменяем ввод этого символа
            }
        }
        private void FactorialRangeTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и клавишу Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // отменяем ввод этого символа
            }
        }
    }

    public abstract class MainClass
    {
        public int Count { get; set; } = 0;
        public int FromText { get; set; }
        public int ToText { get; set; }

        public MainClass(string fromText, string toText)
        {
            FromText = int.Parse(fromText);
            ToText = int.Parse(toText);
        }
    }
    public class SquareCubeClass : MainClass
    {
        public bool IsSquare { get; set; }
        public bool IsCube { get; set; }
        public SquareCubeClass(string fromText, string toText, bool isSquare, bool isCube) : base(fromText, toText)
        {
            IsSquare = isSquare;
            IsCube = isCube;
        }
    }
    public class FactorialClass : MainClass
    {
        public FactorialClass(string fromText, string toText) : base(fromText, toText)
        {
        }
    }
}