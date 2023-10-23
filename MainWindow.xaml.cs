using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Pomodorable
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer; // Declaração de um DispatcherTimer para atualização do tempo.
        private TimeSpan pomodoroTime; // Defina o tempo do Pomodoro
        private int maxDuration;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += Timer_Tick;

            timer.IsEnabled = false;

            btnPomodoro.Click += (sender, e) => StartTimer(25); // Inicie o Pomodoro com duração de 25 minutos
            btnShortBreak.Click += (sender, e) => StartTimer(5); // Inicie a Pausa Curta com duração de 5 minutos
            btnLongBreak.Click += (sender, e) => StartTimer(10); // Inicie a Pausa Longa com duração de 10 minutos
        }

        private void StartTimer(int durationMinutes)
        {
            maxDuration = durationMinutes;
            pomodoroTime = TimeSpan.FromMinutes(maxDuration);
            UpdateTimeStatus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Caso ainda tenha tempo (tenha mais que 0 segundos)
            if (pomodoroTime.TotalSeconds > 0)
            {
                pomodoroTime = pomodoroTime.Subtract(TimeSpan.FromSeconds(1)); // Decrementa o tempo restante em 1 segundo. (Atualiza a label cada vez que a thread atualizar)
                UpdateTimeStatus(); // Atualiza o texto na interface do usuário.

                int intNum = int.Parse(pomodoroTime.TotalSeconds.ToString());
                lblDebug.Content = intNum;

                UpdateProgressBar();


            }
            else
            {
                // O Pomodoro terminou, pare o timer ou implemente a lógica apropriada.
                timer.Stop(); // Interrompe o DispatcherTimer.
                lblStatusMain.Content = "Pomodoro Concluído!"; // Atualiza o status principal na interface do usuário.
                lblTimeStatus.Content = "25:00";

                btnInitialize.Content = "Start";
            }
        }

        private void UpdateProgressBar()
        {
            // Calcular o valor atual da ProgressBar com base no tempo restante
            double progressValue = ((maxDuration - pomodoroTime.TotalMinutes) / maxDuration) * progressBar.Maximum;
            lblDebug.Content = progressValue.ToString();


            if (progressValue >= 0 && progressValue <= progressBar.Maximum)
            {
                progressBar.Value = progressValue;
            }
            else
            {
                progressBar.Value = progressBar.Maximum;
            }
        }

        private void Pomodoro(object sender, RoutedEventArgs e)
        {
            // Iniciar o Pomodoro
            pomodoroTime = TimeSpan.FromMinutes(25); // Reinicie o tempo do Pomodoro para 25 minutos.
            UpdateTimeStatus(); // Atualiza o texto na interface do usuário.
        }

        private void ShortBreak(object sender, RoutedEventArgs e)
        {
            // Iniciar a Pausa Curta
            pomodoroTime = TimeSpan.FromMinutes(5);
            UpdateTimeStatus();
        }

        private void LongBreak(object sender, RoutedEventArgs e)
        {
            // Iniciar a Pausa Longa
            pomodoroTime = TimeSpan.FromMinutes(10);
            UpdateTimeStatus();
        }

        private void UpdateTimeStatus()
        {
            // Utiliza do pomodoroTime pré-definido no começo do código
            lblTimeStatus.Content = $"{pomodoroTime:mm\\:ss}"; // Atualiza o texto do tempo na interface do usuário no formato "mm:ss".
        }














        //-------------------------------------------------------------------------------------------------------------------------



        private void btnInitialize_Click(object sender, RoutedEventArgs e)
        {
            lblStatusMain.Content = "Hora de focar!";

            progressBar.Value = 0;

            if (lblTimeStatus.Content.ToString() == "25:00")
            {
                StartTimer(25);
            }

            if(btnInitialize.Content.ToString() == "Start")
            {
                timer.IsEnabled = true;
                btnInitialize.Content = "Pause";
            }
            else
            {
                timer.IsEnabled = false;
                btnInitialize.Content = "Start";
            }
        }

        private void btnPomodoro_Click(object sender, RoutedEventArgs e)
        {
            // int intNum = int.Parse(pomodoroTime.TotalSeconds.ToString());

            timer.Start();
            timer.IsEnabled = false;
            Pomodoro(sender, e);

            btnInitialize.Content = "Start";
            progressBar.Value = 0;

        }

        private void btnShortBreak_Click(object sender, RoutedEventArgs e)
        {
            // int intNum = int.Parse(pomodoroTime.TotalSeconds.ToString());

            timer.Start();
            timer.IsEnabled = false;
            ShortBreak(sender, e);

            btnInitialize.Content = "Start";
            progressBar.Value = 0;

        }

        private void btnLongBreak_Click(object sender, RoutedEventArgs e)
        {
            // int intNum = int.Parse(pomodoroTime.TotalSeconds.ToString());

            timer.Start();
            timer.IsEnabled = false;
            LongBreak(sender, e);

            btnInitialize.Content = "Start";
            progressBar.Value = 0;

        }

    }
}
