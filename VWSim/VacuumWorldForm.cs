using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using VWSim.Core;

namespace VWSim
{
    public partial class VacuumWorldForm : Form
    {
        private VacuumWorldRenderer _renderer;
        private System.Windows.Forms.Timer _cleaningTimer;
        private int _animationStep = 0;

        VacuumSimulation simulation;

        private CancellationTokenSource _cancellationTokenSource;

        private const int GRID_SIZE = 2;
        private const int PICTUREBOX_SIZE = 250;
        private const int CELL_SIZE = PICTUREBOX_SIZE / GRID_SIZE; // 200x200 per cell

        private const int LOG_DELAY_MS = 2000; // Delay between log updates in milliseconds

        public VacuumWorldForm()
        {
            InitializeComponent();

            InitVacuumSimulation();
            InitRenderer();
            InitCancelButton();
            InitLabelStatus();
            InitCleaningTimer();
        }

        private void InitVacuumSimulation()
        {
            simulation = new VacuumSimulation(
                new VacuumEnvironment(),
                new List<Agent> {
                    new RandomAgent(), new SimpleReflexAgent()
                }
            );
        }

        private void InitRenderer()
        {
            _renderer = new VacuumWorldRenderer(PICTUREBOX_SIZE, CELL_SIZE);
        }

        private void InitLabelStatus()
        {
            labelStatus.Text = "Click SIMULATE to start cleaning.";
        }

        private void InitCancelButton()
        {
            ButtonUtil.SetButtonState(buttonCancel, false); // Disable the Cancel button initially
        }

        private void DrawVacuumEnv()
        {
            Bitmap image = _renderer.Render(simulation.Env);

            if (pictureBoxRAVacuumWorld.Image != null)
            {
                pictureBoxRAVacuumWorld.Image.Dispose();
            }

            pictureBoxRAVacuumWorld.Image = image;
        }

        private void ShowDoneCleaningLabel()
        {
            labelStatus.Text = "DONE.";
        }

        private void InitCleaningTimer()
        {
            _cleaningTimer = new System.Windows.Forms.Timer();
            _cleaningTimer.Interval = 500; // How fast the animation updates (in milliseconds)

            _cleaningTimer.Tick += (s, e) =>
            {
                _animationStep++;
                labelStatus.Text = "Cleaning" + new string('.', (_animationStep % 3) + 1);
            };
        }

        private async void buttonSimulate_Click(object sender, EventArgs e)
        {
            DrawVacuumEnv();

            _cancellationTokenSource = new CancellationTokenSource();
            
            CancellationToken cancellationToken = _cancellationTokenSource.Token;

            ButtonUtil.SetButtonState(buttonSimulate, false);
            ButtonUtil.SetButtonState(buttonCancel, true);

            bool isAllCleaned;

            if (env.Dirts.Count <= 0)
            {
                isAllCleaned = true;
            } else
            {
                isAllCleaned = false;
            }

            try
            {
                richTextBoxRALog.Text = "Creating 2x2 Vacuum World...\n\n";
                richTextBoxRALog.Text += env;

                _cleaningTimer.Start();

                await Task.Delay(LOG_DELAY_MS, cancellationToken);

                for (int step = 0; step < 10; step++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    // Get the percept for the agent
                    var percept = env.Percept(agent);

                    // Agent decides on an action based on the percept
                    var action = agent.Program(percept) as string;

                    // Actuator : Execute the action in the environment
                    env.ExecuteAction(agent, action);

                    // Update and draw the Vacuum World
                    DrawVacuumEnv();

                    // Log the action and the new state of the environment

                    // Percept after action
                    var tup = percept as Tuple<int, int, bool>;

                    string locationText = "(?, ?)";

                    if (tup != null)
                    {
                        locationText = $"({tup.Item1}, {tup.Item2})";
                    }

                    richTextBoxRALog.AppendText($"Step {step + 1}: Action = {action} | Location = {locationText} | Score = {agent.Performance}\n");

                    await Task.Delay(LOG_DELAY_MS, cancellationToken);
                }

                isAllCleaned = env.IsAllCleaned();

                richTextBoxRALog.AppendText($"\nFINAL SCORE: {agent.Performance}\n");
                richTextBoxRALog.AppendText($"\nAll Dirts Cleaned: {isAllCleaned.ToString().ToUpper()}\n");
                richTextBoxRALog.AppendText($"Cleaned Dirts: {env.TotalCleanedCount} / {env.TotalDirtCount}\n");

                ShowDoneCleaningLabel();
            }
            catch (OperationCanceledException)
            {
                isAllCleaned = env.IsAllCleaned();

                richTextBoxRALog.AppendText("\nSimulation canceled by user.\n");
                richTextBoxRALog.AppendText($"\nFINAL SCORE: {agent.Performance}\n");
                richTextBoxRALog.AppendText($"\nAll Dirts Cleaned: {isAllCleaned.ToString().ToUpper()}\n");
                richTextBoxRALog.AppendText($"Cleaned Dirts: {env.TotalCleanedCount} / {env.TotalDirtCount}\n");

                labelStatus.Text = "CANCELLED.";
            }
            finally
            {
                _cleaningTimer.Stop();

                ButtonUtil.SetButtonState(buttonSimulate, true);
                ButtonUtil.SetButtonState(buttonCancel, false);

                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}
