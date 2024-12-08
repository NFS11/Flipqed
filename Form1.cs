using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Flipqed
{
    public partial class Form1 : Form
    {
        private string targetFilePath;
        private Stopwatch stopwatch;
        private Timer gameTimer;
        private TimeSpan timeLimit = TimeSpan.FromMinutes(5);
        private int gamesWon = 0;
        private int gamesLost = 0;
        private List<TimeSpan> fastestTimes = new List<TimeSpan>();

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            LoadFastestTimes();
            UpdateStats();
        }

        private void InitializeGame()
        {
            stopwatch = new Stopwatch();
            gameTimer = new Timer { Interval = 1000 }; // 1 second interval
            gameTimer.Tick += GameTimer_Tick;
        }

        private void LoadFastestTimes()
        {
            if (File.Exists("fasttime.txt"))
            {
                string[] lines = File.ReadAllLines("fasttime.txt");
                fastestTimes = lines
                    .Select(line => TimeSpan.Parse(line))
                    .OrderBy(time => time)
                    .Take(10)
                    .ToList();
            }
        }

        private void SaveFastestTimes()
        {
            File.WriteAllLines("fasttime.txt", fastestTimes.Select(time => time.ToString()));
        }

        private void StartGame()
        {
            targetFilePath = GenerateRandomFile();
            stopwatch.Restart();
            gameTimer.Start();
            MessageBox.Show("Game started! Find the file named 'cantseeme.txt'. You have 5 minutes!");
        }

        private string GenerateRandomFile()
        {
            string[] potentialFolders = new[]
            {
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                Environment.GetFolderPath(Environment.SpecialFolder.Favorites),
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Saved Games")
            };

            Random random = new Random();
            string selectedFolder = potentialFolders[random.Next(potentialFolders.Length)];
            string filePath = Path.Combine(selectedFolder, "cantseeme.txt");

            File.WriteAllText(filePath, "Found!");
            return filePath;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (stopwatch.Elapsed >= timeLimit)
            {
                EndGame(false);
            }
        }

        private void EndGame(bool isWon)
        {
            gameTimer.Stop();
            stopwatch.Stop();

            if (isWon)
            {
                TimeSpan timeTaken = stopwatch.Elapsed;
                MessageBox.Show($"You win! Time taken: {timeTaken.Minutes:D2}:{timeTaken.Seconds:D2}");
                gamesWon++;

                // Save the time if it's one of the fastest
                fastestTimes.Add(timeTaken);
                fastestTimes = fastestTimes.OrderBy(time => time).Take(10).ToList();
                SaveFastestTimes();
            }
            else
            {
                MessageBox.Show($"Time's up! The file directory was: {targetFilePath}");
                gamesLost++;
            }

            // Save game stats (won/lost ratio)
            SaveStats();

            ResetGame();
        }

        private void ResetGame()
        {
            targetFilePath = null;
            stopwatch.Reset();
            gameTimer.Stop();
            UpdateStats();
        }

        private void SaveStats()
        {
            File.WriteAllText("gameStats.txt", $"Games Won: {gamesWon}\nGames Lost: {gamesLost}\nRatio: {(gamesLost == 0 ? "Infinity" : (gamesWon / (double)gamesLost).ToString("F2"))}");
        }

        private void UpdateStats()
        {
            // Display games won/lost and the fastest times in the UI
            gamesStatsLabel.Text = $"Games Won: {gamesWon} | Games Lost: {gamesLost}";
            fastestTimesListBox.Items.Clear();
            foreach (var time in fastestTimes)
            {
                fastestTimesListBox.Items.Add(time.ToString(@"mm\:ss"));
            }
        }

        private void CheckFile(string selectedPath)
        {
            if (string.Equals(selectedPath, targetFilePath, StringComparison.OrdinalIgnoreCase))
            {
                EndGame(true);
            }
            else
            {
                MessageBox.Show("Wrong file! Try again.");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void foundButton_Click(object sender, EventArgs e)
        {
            if (targetFilePath == null)
            {
                MessageBox.Show("The game hasn't even started yet???");
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Where's the file?",
                Filter = "Text Files (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CheckFile(openFileDialog.FileName);
            }
        }

        private void giveUpButton_Click(object sender, EventArgs e)
        {
            if (targetFilePath == null)
            {
                MessageBox.Show("You haven't started the game. Start the game before giving up.");
                return;
            }

            EndGame(false);
        }
    }
}
