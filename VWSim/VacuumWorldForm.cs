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
        private AgentSimulation _randomAgentSimulation;
        private AgentSimulation _simpleReflexAgentSimulation;

        private VacuumSimulation _simulations;

        private VacuumWorldRenderer _renderer;

        private System.Windows.Forms.Timer _cleaningTimer;
        private int _animationStep = 0;


        private CancellationTokenSource _cancellationTokenSource;

        private const int GRID_SIZE = 2;
        private const int PICTUREBOX_SIZE = 350;
        private const int CELL_SIZE = PICTUREBOX_SIZE / GRID_SIZE; // 175x175 per cell

        private const int LOG_DELAY_MS = 1000; // Delay between log updates in milliseconds

        public VacuumWorldForm()
        {
            InitializeComponent();

            InitRenderer();
            InitAgentLabelName();

            InitCancelButton();
            InitLabelStatus();
            InitCleaningTimer();
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

        private void InitSimulations()
        {
            VacuumWorldGenerator generator = new VacuumWorldGenerator();
            VacuumWorldState initialState = generator.Generate();

            VacuumEnvironment randomAgentEnv = new VacuumEnvironment(initialState);
            VacuumEnvironment simpleReflexAgentEnv = new VacuumEnvironment(initialState);

            RandomAgent randomAgent = new RandomAgent();
            SimpleReflexAgent simpleReflexAgent = new SimpleReflexAgent();

            _randomAgentSimulation = new AgentSimulation(randomAgentEnv, randomAgent, "Random Agent");
            _simpleReflexAgentSimulation = new AgentSimulation(simpleReflexAgentEnv, simpleReflexAgent, "Simple Reflex Agent");

            _simulations = new VacuumSimulation(
                            new List<AgentSimulation> { 
                                _randomAgentSimulation, 
                                _simpleReflexAgentSimulation 
                            });
        }

        private void InitAgentLabelName()
        {
            agentSimulationPanelRandom.RenderAgentName("Random Agent");
            agentSimulationPanelSFA.RenderAgentName("Simple Reflex Agent");
        }

        private void InitAgentSimulationPanels()
        {
            agentSimulationPanelRandom.Initialize(_randomAgentSimulation);
            agentSimulationPanelSFA.Initialize(_simpleReflexAgentSimulation);
        }

        private void ShowBreaklineToAgentPanels()
        {
            agentSimulationPanelRandom.PrintBreakLine();
            agentSimulationPanelSFA.PrintBreakLine();
        }

        private void ShowFinalResults(AgentSimulationPanel agentSimulationPanel, AgentSimulation agentSimulation)
        {
            string finalScore = $"FINAL SCORE: {agentSimulation.Agent.Performance}\n\n";
            string cleanedStatus = $"Agent Able To Clean All Dirty Cells: {agentSimulation.Environment.IsAllCleaned().ToString().ToUpper()}\n" +
                                   $"Dirts Cleaned: {agentSimulation.Environment.TotalCleanedCount} / {agentSimulation.Environment.TotalDirtCount}\n";

            agentSimulationPanel.Log(finalScore + cleanedStatus);
        }

        private void ShowDoneCleaningLabel()
        {
            labelStatus.Text = "DONE.";
        }

        private void InitCleaningTimer()
        {
            _cleaningTimer = new System.Windows.Forms.Timer();
            _cleaningTimer.Interval = 500; // How fast the "Cleaning..." animation updates (in milliseconds)

            _cleaningTimer.Tick += (s, e) =>
            {
                _animationStep++;
                labelStatus.Text = "Cleaning" + new string('.', (_animationStep % 3) + 1);
            };
        }

        private async void buttonSimulate_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Cleaning.";

            _cleaningTimer.Start();

            InitSimulations();
            InitAgentSimulationPanels();

            agentSimulationPanelRandom.PrintBreakLine();
            agentSimulationPanelSFA.PrintBreakLine();


            _cancellationTokenSource = new CancellationTokenSource();

            CancellationToken cancellationToken = _cancellationTokenSource.Token;

            ButtonUtil.SetButtonState(buttonSimulate, false);
            ButtonUtil.SetButtonState(buttonCancel, true);

            await Task.Delay(LOG_DELAY_MS);

            try
            {
                int steps = 10;

                for (int i = 0; i < steps; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    List<SimulationStepResult> results = _simulations.RunStep();

                    agentSimulationPanelRandom.UpdateSimulationStep(results[0], i + 1);
                    agentSimulationPanelSFA.UpdateSimulationStep(results[1], i + 1);

                    await Task.Delay(LOG_DELAY_MS, cancellationToken);
                }

                ShowBreaklineToAgentPanels();

                ShowFinalResults(agentSimulationPanelRandom, _randomAgentSimulation);
                ShowFinalResults(agentSimulationPanelSFA, _simpleReflexAgentSimulation);

                ShowDoneCleaningLabel();
            }
            catch (OperationCanceledException)
            {
                ShowBreaklineToAgentPanels();

                ShowFinalResults(agentSimulationPanelRandom, _randomAgentSimulation);
                ShowFinalResults(agentSimulationPanelSFA, _simpleReflexAgentSimulation);

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
