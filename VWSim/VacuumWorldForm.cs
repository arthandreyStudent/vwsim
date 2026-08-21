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
        private AgentSimulation _modelBasedReflexAgentSimulation;

        private VacuumSimulation _simulations;

        private VacuumWorldRenderer _renderer;

        private System.Windows.Forms.Timer _cleaningTimer;
        private int _animationStep = 0;


        private CancellationTokenSource _cancellationTokenSource;

        private const int GRID_SIZE = 2;
        private const int PICTUREBOX_SIZE = 350;
        private const int CELL_SIZE = PICTUREBOX_SIZE / GRID_SIZE; // 175x175 per cell

        private const int LOG_DELAY_MS = 1500; // Delay between log updates in milliseconds

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
            VacuumEnvironment modelBasedReflexAgentEnv = new VacuumEnvironment(initialState);

            RandomAgent randomAgent = new RandomAgent();
            SimpleReflexAgent simpleReflexAgent = new SimpleReflexAgent();
            ModelBasedReflexAgent modelBasedReflexAgent = new ModelBasedReflexAgent();

            _randomAgentSimulation = new AgentSimulation(randomAgentEnv, randomAgent, "Random Agent");
            _simpleReflexAgentSimulation = new AgentSimulation(simpleReflexAgentEnv, simpleReflexAgent, "Simple Reflex Agent");
            _modelBasedReflexAgentSimulation = new AgentSimulation(modelBasedReflexAgentEnv, modelBasedReflexAgent, "Model-Based Reflex Agent");

            _simulations = new VacuumSimulation(
                            new List<AgentSimulation> { 
                                _randomAgentSimulation, 
                                _simpleReflexAgentSimulation,
                                _modelBasedReflexAgentSimulation
                            });
        }

        private void InitAgentLabelName()
        {
            agentSimulationPanelRandom.RenderAgentName("Random Agent");
            agentSimulationPanelSFA.RenderAgentName("Simple Reflex Agent");
            agentSimulationPanelMBRA.RenderAgentName("Model-Based Reflex Agent");
        }

        private void InitAgentSimulationPanels()
        {
            agentSimulationPanelRandom.Initialize(_randomAgentSimulation);
            agentSimulationPanelSFA.Initialize(_simpleReflexAgentSimulation);
            agentSimulationPanelMBRA.Initialize(_modelBasedReflexAgentSimulation);
        }

        private void ShowBreaklineToAgentPanels()
        {
            agentSimulationPanelRandom.PrintBreakLine();
            agentSimulationPanelSFA.PrintBreakLine();
            agentSimulationPanelMBRA.PrintBreakLine();
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

        private async Task RunAgentSimulationAsync(
            AgentSimulation agentSimulation,
            AgentSimulationPanel agentSimPanel,
            CancellationToken cancellationToken,
            int maxSteps = 20
        )
        {
            bool finishedOnOwn = false;

            for (int step = 0; step < maxSteps; step++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (agentSimulation.Agent.AmIDoneCleaningAllDirtyCells)
                {
                    finishedOnOwn = true;
                    agentSimPanel.RenderAgentStatusOverlay("AGENT DONE", Color.LimeGreen);
                    agentSimPanel.Log("\n>>>>>>>>>>>>>>>> AGENT DONE <<<<<<<<<<<<<<<");
                    break;
                }

                SimulationStepResult simResult = agentSimulation.RunStep();

                agentSimPanel.UpdateSimulationStep(simResult, step + 1);

                if (simResult.Action == "NoOp")
                {
                    finishedOnOwn = true;
                    agentSimPanel.RenderAgentStatusOverlay("AGENT DONE", Color.LimeGreen);
                    agentSimPanel.Log("\n>>>>>>>>>>> AGENT DONE <<<<<<<<<<");
                    break;
                }

                await Task.Delay(LOG_DELAY_MS, cancellationToken);
            }

            if (!finishedOnOwn)
            {
                agentSimPanel.RenderAgentStatusOverlay("UNABLE TO INFER", Color.OrangeRed);
            }

            agentSimPanel.PrintBreakLine();
            ShowFinalResults(agentSimPanel, agentSimulation);
        }

        private async void buttonSimulate_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Cleaning.";

            _cleaningTimer.Start();

            InitSimulations();
            InitAgentSimulationPanels();

            ShowBreaklineToAgentPanels();

            _cancellationTokenSource = new CancellationTokenSource();

            CancellationToken cancellationToken = _cancellationTokenSource.Token;

            ButtonUtil.SetButtonState(buttonSimulate, false);
            ButtonUtil.SetButtonState(buttonCancel, true);

            await Task.Delay(LOG_DELAY_MS);

            try
            {
                // Launch all three tasks
                Task randomAgentTask = RunAgentSimulationAsync(_randomAgentSimulation, agentSimulationPanelRandom, cancellationToken);
                Task simpleReflexAgentTask = RunAgentSimulationAsync(_simpleReflexAgentSimulation, agentSimulationPanelSFA, cancellationToken);
                Task mbrAgentTask = RunAgentSimulationAsync(_modelBasedReflexAgentSimulation, agentSimulationPanelMBRA, cancellationToken);

                // Wait for all TASKS to complete
                await Task.WhenAll(randomAgentTask, simpleReflexAgentTask, mbrAgentTask);

                ShowDoneCleaningLabel();
            }
            catch (OperationCanceledException)
            {
                ShowBreaklineToAgentPanels();

                ShowFinalResults(agentSimulationPanelRandom, _randomAgentSimulation);
                ShowFinalResults(agentSimulationPanelSFA, _simpleReflexAgentSimulation);
                ShowFinalResults(agentSimulationPanelMBRA, _modelBasedReflexAgentSimulation);

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
