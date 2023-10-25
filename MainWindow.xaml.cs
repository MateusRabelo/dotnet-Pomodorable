using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Media;
using System.Windows.Media;


namespace Pomodorable
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer; // Declaração de um DispatcherTimer para atualização do tempo.

        private TimeSpan pomodoroTime; // Defina o tempo do Pomodoro

        private int maxDuration;

        private ObservableCollection<TaskItem> tasks = new ObservableCollection<TaskItem>();

        MediaPlayer tickingSound = new MediaPlayer();
        MediaPlayer clickSound = new MediaPlayer();
        MediaPlayer lofiSound = new MediaPlayer();
        MediaPlayer noiseSound = new MediaPlayer();
        MediaPlayer alarmSound = new MediaPlayer();

        public class TaskItem
        {
            public string TaskName { get; set; }
            public bool IsCompleted { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            tickingSound.Open(new Uri("D:\\projetos\\csharp_repo\\Auris\\Pomodorable\\sounds\\sound\\clockThickingSoundEffect.mp3", UriKind.Relative));

            alarmSound.Open(new Uri("D:\\projetos\\csharp_repo\\Auris\\Pomodorable\\sounds\\sound\\clockAlarmSoundEffect.mp3", UriKind.Relative));

            clickSound.Open(new Uri("D:\\projetos\\csharp_repo\\Auris\\Pomodorable\\sounds\\sound\\mouseClickSoundEffect.mp3", UriKind.Relative));

            lofiSound.Open(new Uri("D:\\projetos\\csharp_repo\\Auris\\Pomodorable\\sounds\\music\\lofi1.m4a", UriKind.Relative));

            noiseSound.Open(new Uri("D:\\projetos\\csharp_repo\\Auris\\Pomodorable\\sounds\\sound\\noiseSoundEffect.mp3", UriKind.Relative));

            lbCkeckList.ItemsSource = tasks;


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0);

            timer.Tick += Timer_Tick;

            timer.IsEnabled = false;

            btnPomodoro.Click += (sender, e) =>
            {
                StartTimer(25); // Inicie o Pomodoro com duração de 25 minutos
                handleClickSound();
            };
            btnShortBreak.Click += (sender, e) =>
            {
                StartTimer(5); // Inicie a Pausa Curta com duração de 5 minutos
                handleClickSound();

            };
            btnLongBreak.Click += (sender, e) =>
            {
                StartTimer(10); // Inicie a Pausa Longa com duração de 10 minutos
                handleClickSound();

            };

        }


        //-------------------------------------------------------------------------------------------------------------------------



        private void btnInitialize_Click(object sender, RoutedEventArgs e)
        {
            handleClickSound();

            alarmSound.Stop();

            lblStatusMain.Content = "Hora de focar!";

            lofiSound.Play();
            btnPlayLofiSound.Opacity = 1;

            if (lblTimeStatus.Content.ToString() == "00:00")
            {
                progressBar.Value = 0;
            }

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
                tickingSound.Stop();
                lofiSound.Pause();
                btnPlayLofiSound.Opacity = 0.5;
                btnPlayNoiseSound.Opacity = 0.5;
                noiseSound.Stop();
                btnInitialize.Content = "Start";
            }
        }

        private void btnPomodoro_Click(object sender, RoutedEventArgs e)
        {

            alarmSound.Stop();

            // int intNum = int.Parse(pomodoroTime.TotalSeconds.ToString());

            timer.Start();
            timer.IsEnabled = false;
            Pomodoro(sender, e);

            btnInitialize.Content = "Start";
            progressBar.Value = 0;

        }

        private void btnShortBreak_Click(object sender, RoutedEventArgs e)
        {
            alarmSound.Stop();

            // int intNum = int.Parse(pomodoroTime.TotalSeconds.ToString());

            timer.Start();
            timer.IsEnabled = false;
            ShortBreak(sender, e);

            btnInitialize.Content = "Start";
            progressBar.Value = 0;

        }

        private void btnLongBreak_Click(object sender, RoutedEventArgs e)
        {
            alarmSound.Stop();

            // int intNum = int.Parse(pomodoroTime.TotalSeconds.ToString());

            timer.Start();
            timer.IsEnabled = false;
            LongBreak(sender, e);

            btnInitialize.Content = "Start";
            progressBar.Value = 0;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // fecha a aplicação
        }






        private void btnPlayLofiSound_Click(object sender, RoutedEventArgs e)
        {
            handleClickSound();

            if(timer.IsEnabled == true)
            {
                if (btnPlayLofiSound.Opacity == 1)
                {
                    lofiSound.Pause();
                    btnPlayLofiSound.Opacity = 0.5;
                }
                else
                {
                    lofiSound.Play();
                    btnPlayLofiSound.Opacity = 1;
                }
            }
        }

        private void btnPlayClockTickingSound_Click(object sender, RoutedEventArgs e)
        {
            handleClickSound();

            if (btnPlayClockTickingSound.Opacity == 1)
            {
                tickingSound.Volume = 0;
                btnPlayClockTickingSound.Opacity = 0.5;
            }
            else
            {
                tickingSound.Volume = 100;
                btnPlayClockTickingSound.Opacity = 1;
            }
        }

        private void btnPlayNoiseSound_Click(object sender, RoutedEventArgs e)
        {
            handleClickSound();

            if(timer.IsEnabled == true)
            {
                if (btnPlayNoiseSound.Opacity == 1)
                {
                    btnPlayNoiseSound.Opacity = 0.5;
                    noiseSound.Pause();
                }
                else
                {
                    noiseSound.Play();
                    btnPlayNoiseSound.Opacity = 1;
                }
            }
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            alarmSound.Stop();

            // Mostrar o pop-up para adicionar uma nova tarefa
            popAddTaskContent.IsOpen = true;
        }

        private void popAddTaskContent_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            popAddTaskContent.IsOpen = false;
            handleClickSound();
        }

        private void btnAddTaskPopup_Click(object sender, RoutedEventArgs e)
        {
            string taskName = taskTextBox.Text;

            if (!string.IsNullOrEmpty(taskName))
            {
                // Adicione a tarefa à lista de tarefas
                tasks.Add(new TaskItem { TaskName = taskName, IsCompleted = false });

                // Limpe o TextBox após adicionar a tarefa
                taskTextBox.Text = string.Empty;

                // Feche o pop-up
                popAddTaskContent.IsOpen = false;
            }
        }

        private void btnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            // Obtém o botão que foi clicado
            Button button = (Button)sender;

            // Obtém o item da tarefa associada a este botão
            TaskItem taskToDelete = (TaskItem)button.DataContext;

            // Remove a tarefa da coleção
            tasks.Remove(taskToDelete);
        }











        private void StartTimer(int durationMinutes)
        {
            maxDuration = durationMinutes;
            pomodoroTime = TimeSpan.FromMinutes(maxDuration);
            UpdateTimeStatus();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tickingSound.Stop();
            // Caso ainda tenha tempo (tenha mais que 0 segundos)
            if (pomodoroTime.TotalSeconds > 0)
            {
                tickingSound.Play();
                pomodoroTime = pomodoroTime.Subtract(TimeSpan.FromSeconds(1)); // Decrementa o tempo restante em 1 segundo. (Atualiza a label cada vez que a thread atualizar)
                UpdateTimeStatus(); // Atualiza o texto na interface do usuário.

                int intNum = int.Parse(pomodoroTime.TotalSeconds.ToString());
                lblDebug.Content = intNum;

                UpdateProgressBar();

                if (lofiSound.Position >= lofiSound.NaturalDuration.TimeSpan)
                {
                    // A música terminou, faça algo aqui, como reiniciar a música.
                    lofiSound.Position = TimeSpan.Zero;
                    lofiSound.Play();
                }
                else if (noiseSound.Position >= lofiSound.NaturalDuration.TimeSpan)
                {
                    noiseSound.Position = TimeSpan.Zero;
                    noiseSound.Play();
                }


            }
            else
            {
                lofiSound.Pause();
                noiseSound.Stop();
                alarmSound.Play();
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











        //------------------------------------------------------------- HANDLE FUNCTIONS--------------------------------------------------------------------------





        private void handleClickSound()
        {
            clickSound.Close();
            clickSound.Play();
            

        }
    }
}
